using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chevo.RPG.Common.Helpers.Execution
{
    public interface IExecutionHelper
    {
        void ExecuteContinuoslyAsync(Action someFunc);

        void StopExecute();
    }
}
