using ArtiomOvechko.RPG.Mono.Core.Enum;
using ArtiomOvechko.RPG.Mono.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Mono.ViewModel.Interfaces;
using ArtiomOvechko.RPG.Mono.ViewModel.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArtiomOvechko.RPG.Mono.App
{
    public class GameLevel : Game
    {
        GraphicsDeviceManager graphics;

        // This is the model instance that we'll load
        // our XNB into:
        Model model;

        private ILevel _level;

        private Keys?[] PressedKeys { get; set; } = new Keys?[100];

        SpriteBatch spriteBatch;
        Texture2D healthBackground;
        Texture2D healthForeGround;

        public GameLevel()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;

            Content.RootDirectory = "Content";
            _level = new Sanctuary(1366, 768);
        }

        protected override void LoadContent()
        {
            // Notice that loading a model is very similar
            // to loading any other XNB (like a Texture2D).
            // The only difference is the generic type.
            model = Content.Load<Model>("cube");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            healthBackground = new Texture2D(graphics.GraphicsDevice, 100, 20);
            healthForeGround = new Texture2D(graphics.GraphicsDevice, 100, 20);

            Color[] data = new Color[100 * 20];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.DarkRed;
            healthBackground.SetData(data);

            Color[] data2 = new Color[100 * 20];
            for (int i = 0; i < data2.Length; ++i) data2[i] = Color.Red;
            healthForeGround.SetData(data2);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            ProcessKeyboard();

            _level.Container.ProcessAll();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var cameraPosition = new Vector3(
                -_level.ViewPort.Position.X + _level.ViewPort.ScreenWidth / 2,
                - _level.ViewPort.Position.Y + (_level.ViewPort.ScreenHeight / 2) + 200,
                400);
            var cameraLookAtVector = new Vector3(
                -_level.ViewPort.Position.X + _level.ViewPort.ScreenWidth / 2,
                -_level.ViewPort.Position.Y + (_level.ViewPort.ScreenHeight / 2),
                0);

            for (var i = 0; i < _level.Container.Instances.Items.Length; i++)
            {
                IInstance levelInstance = _level.Container.Instances.Items[i];
                if (levelInstance == null)
                {
                    break;
                }

                if (levelInstance.Actor != null)
                {
                    Vector3 instancePosition = new Vector3(
                        levelInstance.Actor.Position.X, levelInstance.Actor.Position.Y, 0);
                    DrawModel(instancePosition, cameraPosition, cameraLookAtVector);

                    if (levelInstance.Actor.IsHealthBarShown && levelInstance.IsPlayer)
                    {
                        Vector2 healthBarPosition = new Vector2(
                            levelInstance.Actor.HealthBarPosition.X + _level.ViewPort.Position.X,
                            levelInstance.Actor.HealthBarPosition.Y + _level.ViewPort.Position.Y);

                        spriteBatch.Begin(SpriteSortMode.Deferred);

                        spriteBatch.Draw(healthBackground, healthBarPosition, Color.White);
                        spriteBatch.Draw(healthForeGround, healthBarPosition, null,
                            new Rectangle((int)healthBarPosition.X, (int)healthBarPosition.Y,
                            (int)levelInstance.Actor.Stats.HealthPercentage, 20), null, 0, null, Color.White);
                        spriteBatch.End();
                    }
                }
            }

            base.Draw(gameTime);
        }

        private void ProcessKeyboard()
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Keys[] currentlyPressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in currentlyPressedKeys)
            {
                switch (key)
                {
                    case Keys.W:
                        _level.StartMove.Execute(Direction.Up);
                        break;
                    case Keys.D:
                        _level.StartMove.Execute(Direction.Right);
                        break;
                    case Keys.S:
                        _level.StartMove.Execute(Direction.Down);
                        break;
                    case Keys.A:
                        _level.StartMove.Execute(Direction.Left);
                        break;
                    //case Key.Space:
                    //    _currentLevel.Attack.Execute(null);
                    //    return;
                    default: return;
                }
            }

            for (var i = 0; i < PressedKeys.Length; i++)
            {
                if (PressedKeys[i].HasValue)
                {
                    bool keyUp = true;
                    foreach (Keys key in currentlyPressedKeys)
                    {
                        if (key == PressedKeys[i].Value)
                        {
                            keyUp = false;
                        }
                    }

                    if (keyUp)
                    {
                        switch (PressedKeys[i].Value)
                        {
                            case Keys.W:
                                _level.StopMove.Execute(Direction.Up);
                                break;
                            case Keys.D:
                                _level.StopMove.Execute(Direction.Right);
                                break;
                            case Keys.S:
                                _level.StopMove.Execute(Direction.Down);
                                break;
                            case Keys.A:
                                _level.StopMove.Execute(Direction.Left);
                                break;
                            case Keys.Enter:
                                _level.TryInteract.Execute(null);
                                break;
                            //case Key.Space:
                            //    _currentLevel.Attack.Execute(null);
                            //    return;
                            default: return;
                        }
                    }
                }
            }


            PressedKeys = new Keys?[currentlyPressedKeys.Length];

            for (var i = 0; i < currentlyPressedKeys.Length; i++)
            {
                PressedKeys[i] = currentlyPressedKeys[i];
            }
        }

        private void DrawModel(Vector3 modelPosition, Vector3 cameraPosition, Vector3 cameraLookAtVector)
        {
            foreach (var mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.World = Matrix.CreateScale(16) * Matrix.CreateTranslation(modelPosition);
                    var cameraUpVector = Vector3.UnitZ;
                    effect.View = Matrix.CreateLookAt(
                        cameraPosition, cameraLookAtVector, cameraUpVector);
                    float aspectRatio =
                        graphics.PreferredBackBufferWidth / (float)graphics.PreferredBackBufferHeight;
                    float fieldOfView = Microsoft.Xna.Framework.MathHelper.PiOver4;
                    float nearClipPlane = 1;
                    float farClipPlane = 1000;
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
                }
                // Now that we've assigned our properties on the effects we can
                // draw the entire mesh
                GraphicsDevice.DepthStencilState = DepthStencilState.Default;
                mesh.Draw();
            }
        }
    }
}