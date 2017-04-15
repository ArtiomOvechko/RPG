using Chevo.RPG.Core.Actor;
using Chevo.RPG.Core.Behavior;
using Chevo.RPG.Core.Behavior.Npc;
using Chevo.RPG.Core.Behavior.StaticObject;
using Chevo.RPG.Core.Environment;
using Chevo.RPG.Core.Interaction;
using Chevo.RPG.Core.Interfaces.Instance;
using Chevo.RPG.Core.Inventory.Item;
using Chevo.RPG.Core.Inventory.Weapon;
using Chevo.RPG.Core.Stats;
using Chevo.RPG.ViewModel.Control;


namespace Chevo.RPG.ViewModel.Level
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

            // Init Player         
            Player = new Player(new Thief(new KnifeWeaponItem(null), new Point(2700, 2700)), new InteractionHandler(new Messenger()));
            ViewPort = new ViewPort(screenWidth, screenHeight, (IInstance)Player);

            // Render all obstacles
            EnvironmentContainer.AddInstance(wall1);
            EnvironmentContainer.AddInstance(wall2);
            EnvironmentContainer.AddInstance(GuideChar);
            EnvironmentContainer.AddInstance((IInstance)Player);

            // Render all items
            EnvironmentContainer.Items.Add(CopperKey);
            EnvironmentContainer.Items.Add(CopperKey3);
            EnvironmentContainer.Items.Add(Knife);

            //Run environment
            EnvironmentContainer.Run();
        }
    }
}
