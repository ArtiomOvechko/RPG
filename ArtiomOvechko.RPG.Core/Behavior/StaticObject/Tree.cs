using ArtiomOvechko.RPG.Core.Interfaces.Actor;
using ArtiomOvechko.RPG.Core.Interfaces.Interaction;

using System;

namespace ArtiomOvechko.RPG.Core.Behavior.StaticObject
{
    
    public class Tree : BaseBehavior, IBehavior
    {
        public Tree(IActor actor) : base(actor) { }

        public string GetMessage()
        {
            return "";
        }

        protected override void ProcessCurrentState() { }
    }
}
