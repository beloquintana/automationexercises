using AutomationFramework.Handler;
using NUnit.Framework;

namespace AutomationFramework
{
    [SetUpFixture]
    public class SuiteSetUp
    {
        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {

        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {

        }
    }
}
