using Chevo.RPG.Core.Interfaces.Actor;

using System;
using System.Threading;


namespace Chevo.RPG.Core.Behavior
{
    [Serializable]
    public abstract class BaseBehavior
    {
        [NonSerialized]
        protected CancellationTokenSource _cts;
        protected IActor _currentActor;

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
            //if (!_currentActor.Stats.IsAlive)
            //{
            //    _cts.Cancel();
            //}
        }
    }
}
