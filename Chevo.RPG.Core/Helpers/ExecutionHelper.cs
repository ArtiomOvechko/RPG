using Chevo.RPG.Common;

using System;
using System.Threading;
using System.Threading.Tasks;


namespace Chevo.RPG.Core.Helpers
{
    public class ExecutionHelper
    {
        //private static ExecutionHelper _instance;
       // private static volatile object _lock = new object();

        public static ExecutionHelper GetNew
        {
            get
            {
                return new ExecutionHelper();
            }           
        }

        //private ExecutionHelper() { }

        public async Task ExecuteContinuoslyAsync(Action someFunc, CancellationToken cancellationToken)
        {
            await Task.Delay(GlobalSettings.Default.GameSpeed);
            someFunc();
            if (!cancellationToken.IsCancellationRequested)
            {
                await ExecuteContinuoslyAsync(someFunc, cancellationToken);
            }
        }

        public async Task ExecuteContinuoslyAsyncWithPostAction(Action continuousAction, Action postAction, CancellationToken cancellationToken)
        {
            await Task.Delay(GlobalSettings.Default.GameSpeed);
            continuousAction();
            if (!cancellationToken.IsCancellationRequested)
            {
                await ExecuteContinuoslyAsyncWithPostAction(continuousAction, postAction, cancellationToken);
            } else
            {
                postAction();
            }
        }

        public async Task ExecuteWithDelayAsync(Action delayedAction, int delayTime)
        {
            await Task.Delay(delayTime);
            delayedAction();
        }
    }
}
