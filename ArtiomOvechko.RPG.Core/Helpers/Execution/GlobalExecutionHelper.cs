using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chevo.RPG.Common.Helpers.Execution
{
    public class GlobalExecutionHelper
    {
        private static GlobalExecutionHelper _instance;
        private static volatile object _lock = new object();

        public static GlobalExecutionHelper GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GlobalExecutionHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private GlobalExecutionHelper() { }

        public async Task ExecuteContinuoslyAsync(Action someFunc, CancellationToken cancellationToken)
        {
            await Task.Delay(GlobalSettings.Default.GameSpeed);
            someFunc();
            if (!cancellationToken.IsCancellationRequested)
            {
                await ExecuteContinuoslyAsync(someFunc, cancellationToken);
            }
        }
    }
}
