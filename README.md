## Automation Exercises
## Automation Framework
## C#
## NUnit
| Anotación       | Descripción   |
| -------------   | ------------- |
| TestFixture     | Marca a una clase que va a contener casos de pruebas  |
| Test            | Marca a un método como un caso de prueba  |
| SetUp           | Indica a un método que se va a ejecutar antes de cada test  |
| TearDown        | Indica a un método que se va a ejecutar después de cada test   |
| SetUpFixture    | Marca a una clase con "OneTimeSetUp" o "OneTimeTearDown" para todos los test en un mismo namespace |
| OneTimeSetUp    | Indica a un método que se va a ejecutar una sola vez antes de todos los test  |
| OneTimeTearDown | Indica a un método que se va a ejecutar una sola vez después de todos los test  |
| TestCase        | Permite parametrizar casos de prueba  |

**Ejemplo TestCase:**
```c#
        [TestCase("10", "8")]
        public void SumTest(float number1, float number2)
        {
            float sum = number1 + number2;
            //...
        }
```

Mas información en: https://github.com/nunit/docs/wiki/Attributes

## Selenium WebDriver
## ExtentReports
```c#
            var htmlReporter = new ExtentHtmlReporter(TestContext.CurrentContext.TestDirectory + "\\Report.html");
            htmlReporter.LoadConfig(TestContext.CurrentContext.TestDirectory + "\\extent-config.xml");
            Instance.AttachReporter(htmlReporter);

            ExtentTest Test = ReportHandler.Instance.CreateTest(TestContext.CurrentContext.Test.Name);

            Test.Log(Status.Info, "SuccessfulLogin");
            Test.AddScreenCaptureFromPath(ScreenShotHandler.TakeScreenShot(Driver));

            ReportHandler.Instance.Flush();
```
```c#
        [TearDown]
        public void AfterBaseTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
                Status logstatus;

                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        Test.AddScreenCaptureFromPath(ScreenShotHandler.TakeScreenShot(Driver));
                        break;
                    case TestStatus.Inconclusive:
                        logstatus = Status.Warning;
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        break;
                    default:
                        logstatus = Status.Pass;
                        break;
                }

                Test.Log(logstatus, "Test ended with " + logstatus + stacktrace);                
            }
            catch (Exception e)
            {
                Test.Log(Status.Error, "Exception " + e.Message);
            }
            finally
            {                
                if (Driver != null)
                {
                    Driver.Quit();
                }
            }            
        }
```
## Applitools
```c#
            Eyes eyes = new Eyes();
            eyes.ApiKey = "1254dddccc_lñ222";

            IWebDriver driver = new ChromeDriver();
            eyes.Open(Driver, "AutomationFramework", TestContext.CurrentContext.Test.Name);
            Driver.Url = "https://www.google.com/";

            eyes.CheckWindow("Google Page");
            eyes.Close();
```
```c#
        private void LogApplitools()
        {
            var throwtTestCompleteException = false;
            Applitools.TestResults result = eyes.Close(throwtTestCompleteException);
            string url = result.Url;
            if (result.IsNew)
                Test.Log(Status.Info, "New Baseline Created: URL=" + url);
            else if (result.IsPassed)
                Test.Log(Status.Info, "Visual check Passed: URL=" + url);
            else
                Test.Log(Status.Info, "Visual check Failed: URL=" + url);
        }
```
## Parallel Test Execution
```c#
[assembly: Parallelizable(ParallelScope.Fixtures)]
```

