using Chevo.RPG.WebApp.Common;

using System;
using System.Threading;
using System.Threading.Tasks;
using Chevo.RPG.WebApp.Common.Settings;


namespace Chevo.RPG.WebApp.Core.Helpers
{
    public class ExecutionHelper
    {
        public static ExecutionHelper GetNew
        {
            get
            {
                return new ExecutionHelper();
            }           
        }

        public async Task ExecuteContinuoslyAsync(Action someFunc, CancellationToken cancellationToken)
        {
            await Task.Delay(GlobalSettings.GameStepDelay);
            someFunc();
            if (!cancellationToken.IsCancellationRequested)
            {
                await ExecuteContinuoslyAsync(someFunc, cancellationToken);
            }
        }

        public async Task ExecuteWithDelayAsync(Action delayedAction, int delayTime)
        {
            await Task.Delay(delayTime);
            delayedAction();
        }
    }
}
