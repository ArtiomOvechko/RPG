using ArtiomOvechko.RPG.Desktop.Common;

using System;
using System.Threading;
using System.Threading.Tasks;
using ArtiomOvechko.RPG.Desktop.Common.Settings;


namespace ArtiomOvechko.RPG.Desktop.Core.Helpers
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
