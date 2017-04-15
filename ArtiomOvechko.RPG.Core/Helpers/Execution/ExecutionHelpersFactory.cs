namespace Chevo.RPG.Common.Helpers.Execution
{
    public class ExecutionHelpersFactory
    {
        public static IExecutionHelper getExecutionHelper()
        {
            return new DefaultExecutionHelper();
        }
    }
}
