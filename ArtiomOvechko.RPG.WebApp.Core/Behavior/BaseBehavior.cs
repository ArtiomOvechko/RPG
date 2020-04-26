using Chevo.RPG.WebApp.Core.Interfaces.Actor;

using System;
using System.Threading;


namespace Chevo.RPG.WebApp.Core.Behavior
{
    [Serializable]
    public abstract class BaseBehavior
    {
        public bool IsPlayer { get; protected set; }
        
        [NonSerialized]
        protected CancellationTokenSource _cts;
        protected IActor _currentActor;

        public string Name { get; protected set; }

        public IActor Actor
        {
            get
            {
                return _currentActor;
            }

            private set
            {
                _currentActor = value;
            }
        }

        public BaseBehavior() { }
        //public async void Execute()
        //{
        //    await ExecutionHelper.GetNew.ExecuteContinuoslyAsync(() =>
        //    {
        //        ProcessCurrentState();
        //    }, _cts.Token);
        //}

        public virtual void ProcessCurrentState()
        {
            _currentActor?.ProcessCurrentState();
        }
    }
}
