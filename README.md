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

Mas información en: https://github.com/nunit/docs/wiki/Attributes

## Selenium WebDriver
## ExtentReports
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
## Parallel Test Execution

