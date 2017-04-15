using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArtiomOvechko.RPG.Common.Helpers
{
    public class ExecutionHelper
    {
        private static ExecutionHelper _instance;
        private static volatile object _lock = new object();

        public static ExecutionHelper GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ExecutionHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private ExecutionHelper() { }

        public async Task ExecuteContinuoslyAsync(Action someFunc, int interval, CancellationToken cancellationToken)
        {
            await Task.Delay(interval);
            someFunc();
            if (!cancellationToken.IsCancellationRequested)
            {
                await ExecuteContinuoslyAsync(someFunc, interval, cancellationToken);
            }
        }
    }
}
