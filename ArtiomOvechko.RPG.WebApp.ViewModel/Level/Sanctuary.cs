using Chevo.RPG.WebApp.Core.Actor;
using Chevo.RPG.WebApp.Core.Behavior;
using Chevo.RPG.WebApp.Core.Behavior.Npc;
using Chevo.RPG.WebApp.Core.Behavior.StaticObject;
using Chevo.RPG.WebApp.Core.Environment;
using Chevo.RPG.WebApp.Core.Interaction;
using Chevo.RPG.WebApp.Core.Interfaces.Instance;
using Chevo.RPG.WebApp.Core.Inventory.Item;
using Chevo.RPG.WebApp.Core.Inventory.Weapon;
using Chevo.RPG.WebApp.Core.Stats;
using Chevo.RPG.WebApp.ViewModel.Control;


namespace Chevo.RPG.WebApp.ViewModel.Level
{
    public class Sanctuary: BaseOfflineLevel
    {
        public override IEnvironmentContainer Container { get; protected set; }
        public Sanctuary(int screenWidth, int screenHeight) : base(screenWidth, screenHeight)
        {
            if (Container == null)
            {
                IEnvironmentContainer environment = new EnvironmentContainer();
                Container = environment;

                LevelWidth = Common.Settings.GlobalSettings.LevelWidth;
                LevelHeight = Common.Settings.GlobalSettings.LevelHeight;
                environment.Instances = LevelObjects;
                LevelItems = environment.Items;

                // Add Terrain
                var wall1 = new StaticObjectBehavior(new DungeonStoneWall(new Point(2400, 2600), environment));
                var wall2 = new StaticObjectBehavior(new DungeonStoneWall(new Point(2900, 2900), environment));

                // Add Items
                var CopperKey = new CopperKeyItem(new Point(2500, 2500));
                var CopperKey3 = new CopperKeyItem(new Point(2560, 2500));
                var Knife = new KnifeWeaponItem(new Point(3000, 2500));

                // Add NPC
                var GuideChar = new GuideBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(3000, 2600), environment));

                var TestEnemy1 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(3000, 2800), environment));
                var TestEnemy2 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(2500, 2400), environment));
                var TestEnemy3 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(2700, 2800), environment));
                var TestEnemy4 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(2500, 3100), environment));

                // Init Player         
                var playerActor = new Thief(new KnifeWeaponItem(null), new Point(2700, 2700), environment);
                Player = new Player(playerActor);
                //Player = new Player(playerActor, new InteractionHandler(new Messenger()));
                ViewPort = new ViewPort(screenWidth, screenHeight, (IInstance)Player);

                // Load all obstacles
                environment.AddInstance(wall1);
                environment.AddInstance(wall2);
                environment.AddInstance(GuideChar);
                environment.AddInstance(TestEnemy1);
                environment.AddInstance(TestEnemy2);
                environment.AddInstance(TestEnemy3);
                environment.AddInstance(TestEnemy4);

                for (var i = 3000; i < 3500; i+= 50)
                {
                    environment.AddInstance(new GuideBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(i, i), environment)));
                }

                for (var i = 32; i < 6000; i += 32)
                {
                    environment.AddInstance(new StaticObjectBehavior(new DungeonStoneWall(new Point(i, 3000), environment)));
                }

                environment.AddInstance((IInstance)Player);

                // Load all items
                environment.Items.Add(CopperKey);
                environment.Items.Add(CopperKey3);
                environment.Items.Add(Knife);
            }
            else
            {
                IEnvironmentContainer environment = Container;

                LevelWidth = Common.Settings.GlobalSettings.LevelWidth;
                LevelHeight = Common.Settings.GlobalSettings.LevelHeight;
                LevelObjects = environment.Instances;
                LevelItems = environment.Items;
                
                // Init Player         
                var playerActor = new Thief(new KnifeWeaponItem(null), new Point(2600, 2700), environment);
                Player = new Player(playerActor);
                //Player = new Player(playerActor, new InteractionHandler(new Messenger()));
                ViewPort = new ViewPort(screenWidth, screenHeight, (IInstance)Player);
                
                environment.AddInstance((IInstance)Player);
            }
            
            SubscribeOnEvents();
        }
    }
}
