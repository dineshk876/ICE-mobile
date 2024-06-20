using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BDD_AutomationTests.Utility;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.IO;
using Serilog.Core;
using Serilog;
using Serilog.Events;

namespace BDD_AutomationTests.Hooks
{
    [Binding]
    public class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;

        public static AppConfig config;

        public static String logPath = dir.Replace("bin\\Debug\\net6.0", "Logs");

        public static IWebDriver driver;

        static string configFilePath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "appsettings.json";
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            config = new AppConfig();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configFilePath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

            //Initiating Extents Report
            ExtentReportInit();

            //Logging
            LoggingLevelSwitch levelswitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.ControlledBy(levelswitch)
                        .WriteTo.File(logPath + @"\Logfile_",
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message}{NewLine} ",
                        rollingInterval: RollingInterval.Day).CreateLogger();
            Log.Information("                            BEGINNING OF TEST EXECUTION                           ");
            Log.Information("==================================================================================");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //Running after test run
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Running before feature
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);

            //LogEvent
            Log.Information("Selecting feature file {0} to run", featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            //Running after feature
        }

        [BeforeScenario("@Testers")]
        public void BeforeScenarioWithTag()
        {
            //Running inside tagged hooks in specflow
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {

            //LogEvent
            Log.Information("Selecting scenario {0} to run", scenarioContext.ScenarioInfo.Title);

            //Running before scenario
            switch (config.Browser.ToLower())
            {
                case "chrome":
                    {
                        driver = new ChromeDriver();
                        break;
                    }
                case "ie":
                    {
                        driver = new InternetExplorerDriver();
                        break;
                    }
                case "edge":
                    {
                        driver = new EdgeDriver();
                        break;
                    }
                case "firefox":
                    {
                        driver = new FirefoxDriver();
                        break;
                    }
                case "safari":
                    {
                        driver = new SafariDriver();
                        break;
                    }
                default:
                    {
                        driver = new ChromeDriver();
                        break;
                    }
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Running after scenario
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                //driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            //Running after step
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            //LogEvent
            if (scenarioContext.TestError == null)
            {
                Log.Information("{0}", scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                Log.Error("Test step failed | " + scenarioContext.TestError.Message + scenarioContext.TestError.StackTrace);
            }

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (config.TakeScreenShotForAllSteps.ToLower() == "no")
                {
                    if (stepType == "Given")
                    {
                        _scenario.CreateNode<Given>(stepName);
                    }
                    else if (stepType == "When")
                    {
                        _scenario.CreateNode<When>(stepName);
                    }
                    else if (stepType == "Then")
                    {
                        _scenario.CreateNode<Then>(stepName);
                    }
                    else if (stepType == "And")
                    {
                        _scenario.CreateNode<And>(stepName);
                    }
                }
                if (config.TakeScreenShotForAllSteps.ToLower() == "yes")
                {
                    if (stepType == "Given")
                    {
                        _scenario.CreateNode<Given>(stepName).Pass("",
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                    }
                    else if (stepType == "When")
                    {
                        _scenario.CreateNode<When>(stepName).Pass("",
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                    }
                    else if (stepType == "Then")
                    {
                        _scenario.CreateNode<Then>(stepName).Pass("",
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                    }
                    else if (stepType == "And")
                    {
                        _scenario.CreateNode<And>(stepName).Pass("",
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                    }
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, stepName)).Build());
                }
            }

        }
    }
}
