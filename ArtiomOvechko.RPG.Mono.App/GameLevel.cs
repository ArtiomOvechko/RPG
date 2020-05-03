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
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
                Exit();
            
            _level.Container.ProcessAll();

            // position.X += 1;
            // if (position.X > this.GraphicsDevice.Viewport.Width)
            //     position.X = 0;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

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
                        levelInstance.Actor.Position.X + _level.ViewPort.Position.X, 
                        levelInstance.Actor.Position.Y + _level.ViewPort.Position.Y, 0);
                    DrawModel(instancePosition);
                }
            }

            base.Draw(gameTime);
        }

        void DrawModel(Vector3 modelPosition)
        {
            foreach (var mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.World = Matrix.CreateTranslation(modelPosition);
                    var cameraPosition = new Vector3(493, 660, 60);
                    var cameraLookAtVector = new Vector3(493, 274, 0);
                    var cameraUpVector = Vector3.UnitZ;
                    effect.View = Matrix.CreateLookAt(
                        cameraPosition, cameraLookAtVector, cameraUpVector);
                    float aspectRatio =
                        graphics.PreferredBackBufferWidth / (float)graphics.PreferredBackBufferHeight;
                    float fieldOfView = Microsoft.Xna.Framework.MathHelper.PiOver4;
                    float nearClipPlane = 1;
                    float farClipPlane = 20000;
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        fieldOfView, aspectRatio, nearClipPlane, farClipPlane);
                }
                // Now that we've assigned our properties on the effects we can
                // draw the entire mesh
                mesh.Draw();
            }
        }
    }
}