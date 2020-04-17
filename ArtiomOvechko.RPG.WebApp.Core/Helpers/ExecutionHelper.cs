using Chevo.RPG.WebApp.Common;

using System;
using System.Threading;
using System.Threading.Tasks;
using Chevo.RPG.WebApp.Common.Settings;

//using Windows.Foundation.Metadata;

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

        // TBR
        //[Deprecated("Use ExecutionHelper.ExecuteContinuoslyAsync instead", DeprecationType.Deprecate, 1)]
        public async Task ExecuteContinuoslyAsyncWithPostAction(Action continuousAction, Action postAction, CancellationToken cancellationToken)
        {
            await Task.Delay(GlobalSettings.GameStepDelay);
            continuousAction();
            if (!cancellationToken.IsCancellationRequested)
            {
                await ExecuteContinuoslyAsyncWithPostAction(continuousAction, postAction, cancellationToken);
            } else
            {
                postAction();
            }
        }
    }
}
