using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using Redcarpet.BDDtesting.ComponentHelper;
using Redcarpet.BDDtesting.Configuration;
using System;
using TechTalk.SpecFlow;

namespace Redcarpet.BDDtesting
{
    [Binding]
    public class BaseClass
    {
        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        /*private static KlovReporter klov;*/

        private ScenarioContext _scenarioContext;
        public BaseClass(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static FirefoxProfile GetFirefoxProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            return profile;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.Profile = GetFirefoxProfile();
            firefoxOptions.AcceptInsecureCertificates = true;
            return firefoxOptions;
        }

        private static FirefoxOptions GetOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,

            };
            return options;
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");

            option.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
            //option.AddArgument("--headless");
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            return options;
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxOptions());
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        private static EdgeDriver GetEdgeDriver()
        {
            EdgeDriverService edgeDriverService = EdgeDriverService.CreateDefaultService();
            edgeDriverService.HideCommandPromptWindow = true;
            EdgeDriver edgeDriver = new EdgeDriver(edgeDriverService);
            return edgeDriver;
        }

        [BeforeTestRun]
        public static void InitWebdriver()
        {
            PropertiesCollection.Config = new AppConfigReader();
            switch (PropertiesCollection.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    PropertiesCollection.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    PropertiesCollection.Driver = GetChromeDriver();
                    break;

                case BrowserType.IExplorer:
                    PropertiesCollection.Driver = GetIEDriver();
                    break;
                case BrowserType.Edge:
                    PropertiesCollection.Driver = GetEdgeDriver();
                    break;

                default:
                    throw new NoSutiableDriverFound("Driver Not Found : " + PropertiesCollection.Config.GetBrowser().ToString());
            }
            PropertiesCollection.Driver.Manage().Cookies.DeleteAllCookies();
            PropertiesCollection.Driver.Manage()
                            .Timeouts().PageLoad = TimeSpan.FromSeconds(PropertiesCollection.Config.GetPageLoadTimeOut());
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut());
            PropertiesCollection.Driver.Manage().Window.Maximize();
        }

        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\TailorJ\source\repos\PILIR Claims\PILIR Claims\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            /*klov = new KlovReporter();

            klov.InitMongoDbConnection("Localhost", 27017);
            klov.ProjectName = "PILIR Claims";
            klov.ReportName = "Jigar Tailor " + DateTime.Now.ToString();
            //URL of Klov server
            klov.KlovUrl = "http://localhost:5689";

            extent.AttachReporter(htmlReporter, klov);*/

            extent.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            //extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            //featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [AfterStep]
        public void InsertReportingSteps()
        {
            /*            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

                        *//*PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
                        MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                        object TestResult = getter.Invoke(ScenarioContext.Current, null);*//*

                        if (_scenarioContext.TestError == null)
                        {
                            if (stepType == "Given")
                                scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                            else if (stepType == "When")
                                scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                            else if (stepType == "Then")
                                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                            else if (stepType == "And")
                                scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                        }
                        else if (_scenarioContext.TestError != null)
                        {
                            if (stepType == "Given")
                                scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                            else if (stepType == "When")
                                scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                            else if (stepType == "Then")
                                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                            else if (stepType == "And")
                                scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                        }

                        //Pending Status
                        if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                        {
                            if (stepType == "Given")
                                scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            else if (stepType == "When")
                                scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            else if (stepType == "Then")
                                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                            else if (stepType == "And")
                                scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

                        }*/
        }

        [BeforeScenario]
        public void Initialize()
        {
            //Create dynamic scenario name
            //scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void TearDown()
        {
            if (PropertiesCollection.Driver != null)
            {
                PropertiesCollection.Driver.Close();
                PropertiesCollection.Driver.Quit();
            }
        }
    }
}
