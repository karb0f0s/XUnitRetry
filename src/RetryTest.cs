using System;
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
        public void Exception_Fail_Test()
        {
            throw new Exception();
        }

        // Will fail
        [Retry(3, typeof(Exception))]
        public void Assert_Fail_Test()
        {
            Assert.Equal(1, 2);
        }
    }
}
