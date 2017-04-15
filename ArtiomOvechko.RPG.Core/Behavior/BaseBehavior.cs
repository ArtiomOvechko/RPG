using ArtiomOvechko.RPG.Common;
using ArtiomOvechko.RPG.Common.Helpers;
using ArtiomOvechko.RPG.Common.Settings;
using ArtiomOvechko.RPG.Core.Interfaces.Actor;

using System;
using System.Threading;


namespace ArtiomOvechko.RPG.Core.Behavior
{
    
    public abstract class BaseBehavior
    {        
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

        public BaseBehavior(IActor actor)
        {
            _currentActor = actor;

            _cts = new CancellationTokenSource();
        }

        public void Execute()
        {
            ExecutionHelper.GetInstance.ExecuteContinuoslyAsync(() =>
            {
                ProcessCurrentState();
            }, GlobalSettings.GameStepDelay, _cts.Token);
        }

        protected abstract void ProcessCurrentState();
    }
}
