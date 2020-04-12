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
        public Sanctuary(int screenWidth, int screenHeight) : base(screenWidth, screenHeight)
        {
            LevelWidth = Common.Settings.GlobalSettings.LevelWidth;
            LevelHeight = Common.Settings.GlobalSettings.LevelHeight;
            LevelObjects = EnvironmentContainer.Instances;
            LevelItems = EnvironmentContainer.Items;

            // Add Terrain
            var wall1 = new StaticObjectBehavior(new DungeonStoneWall(new Point(2400, 2600)));
            var wall2 = new StaticObjectBehavior(new DungeonStoneWall(new Point(2900, 2900)));

            // Add Items
            var CopperKey = new CopperKeyItem(new Point(2500, 2500));
            var CopperKey3 = new CopperKeyItem(new Point(2560, 2500));
            var Knife = new KnifeWeaponItem(new Point(3000, 2500));

            // Add NPC
            var GuideChar = new GuideBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(3000, 2600)));

            var TestEnemy1 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(3000, 2800)));
            var TestEnemy2 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(2500, 2400)));
            var TestEnemy3 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(2700, 2800)));
            var TestEnemy4 = new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(2500, 3100)));

            // Init Player         
            var playerActor = new Thief(new KnifeWeaponItem(null), new Point(2700, 2700));
            Player = new Player(playerActor, new InteractionHandler(new Messenger()));
            //Player = new Player(playerActor, new InteractionHandler(new Messenger()));
            ViewPort = new ViewPort(screenWidth, screenHeight, (IInstance)Player);

            // Load all obstacles
            EnvironmentContainer.AddInstance(wall1);
            EnvironmentContainer.AddInstance(wall2);
            EnvironmentContainer.AddInstance(GuideChar);
            EnvironmentContainer.AddInstance(TestEnemy1);
            EnvironmentContainer.AddInstance(TestEnemy2);
            EnvironmentContainer.AddInstance(TestEnemy3);
            EnvironmentContainer.AddInstance(TestEnemy4);

            //for (var i = 3000; i < 3500; i+= 50)
            //{
            //    EnvironmentContainer.AddInstance(new TestEnemyBehavior(new Sceleton(new KnifeWeaponItem(null), new Point(i, i))));
            //}

            //for (var i = 32; i < 6000; i += 32)
            //{
            //    EnvironmentContainer.AddInstance(new StaticObjectBehavior(new DungeonStoneWall(new Point(i, 3000))));
            //}

            EnvironmentContainer.AddInstance((IInstance)Player);

            // Load all items
            EnvironmentContainer.Items.Add(CopperKey);
            EnvironmentContainer.Items.Add(CopperKey3);
            EnvironmentContainer.Items.Add(Knife);

            //Run environment
            EnvironmentContainer.Run();
        }
    }
}
