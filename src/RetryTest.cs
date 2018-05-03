using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace XUnitRetry
{
    public class RetryTest
    {
        // Will retry 3 times
        [Retry]
        public void Assert_Fail_Test_And_Retry()
        {
            Assert.Equal(1, 2);
        }

        // Will retry 5 times
        [Retry(5, typeof(Exception))]
        public void Exception_Fail_And_Retry_Test()
        {
            throw new Exception();
        }

        // Will fail
        [Retry(3, typeof(Exception))]
        public void Assert_Fail_Test()
        {
            Assert.Equal(1, 2);
        }

        [Retry(4, typeof(TaskCanceledException))]
        public async Task Async_Exception_Fail_And_Retry_Test()
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await Task.Delay(30_000, cts.Token);
        }

        [Retry(4, typeof(Exception))]
        public async Task Async_Exception_Fail__Test()
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await Task.Delay(30_000, cts.Token);
        }
    }
}
