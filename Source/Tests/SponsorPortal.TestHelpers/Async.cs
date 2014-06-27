using System.Threading.Tasks;

namespace SponsorPortal.TestHelpers
{
    public static class Async
    {
        /// <summary>
        /// Pauses execution asynchronously to allow running tasks to complete before continuing. Necessary for example in order to
        /// allow a projection's event subscription callback to be invoked by the eventstore before trying to get applications
        /// </summary>
        /// <param name="milliseconds">The amount of milliseconds to pause for</param>
        /// <returns></returns>
        public static async Task PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing(int milliseconds = 250)
        {
             await Task.Delay(milliseconds);
        }
    }
}
