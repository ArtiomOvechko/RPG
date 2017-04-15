using ArtiomOvechko.RPG.Core.Actor;
using ArtiomOvechko.RPG.Core.Animation;
using ArtiomOvechko.RPG.Core.Behavior.Npc;
using ArtiomOvechko.RPG.Core.Behavior.StaticObject;
using ArtiomOvechko.RPG.Core.Collision;
using ArtiomOvechko.RPG.Core.Interaction;
using ArtiomOvechko.RPG.Core.Interfaces.Instance;
using ArtiomOvechko.RPG.Core.Spec;
using ArtiomOvechko.RPG.Core.Weapon;
using ArtiomOvechko.RPG.ViewModel.Control;

using System.Collections.ObjectModel;

namespace ArtiomOvechko.RPG.ViewModel.Level
{
    public class Sanctuary: BaseOfflineLevel
    {
        public Sanctuary() : base()
        {
            LevelObjects = new ObservableCollection<IInstance>();

            // Add Terrain
            var Tree1 = new Tree(new Thief(null, new TreeAnimation(), new Spec(2600, 2600), LevelObjects, new DefaultCollisionResolver()));
            var Tree2 = new Tree(new Thief(null, new TreeAnimation(), new Spec(2900, 2900), LevelObjects, new DefaultCollisionResolver()));

            // Add NPC
            var GuideChar = new Guide(new Thief(new Knife(), new Spec(3000, 2600), LevelObjects, new DefaultCollisionResolver()));

            // Init Player
            Spec playerSpec = new Spec(2700, 2700);

            Interactor = new InteractionHandler(new Messenger());
            Player = new Player(new Sceleton(new Knife(), playerSpec, LevelObjects, new DefaultCollisionResolver()), ViewPort, Interactor);

            // Render all obstacles
            LevelObjects.Add(Tree1);
            LevelObjects.Add(Tree2);
            LevelObjects.Add(GuideChar);
            LevelObjects.Add((IInstance)Player);

            // Run NPC
            GuideChar.Execute();
        }
    }
}
