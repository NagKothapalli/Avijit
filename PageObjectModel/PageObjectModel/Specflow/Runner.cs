using OpenQA.Selenium;
using PageObjectModel.AppUtils;
using PageObjectModel.GeneralUtils;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PageObjectModel.Specflow
{
    [Binding]
    public class Runner : ReportGenarator
    {
        public static ExtentReports Extent;
        public static ExtentTest ParentTest;
        public static ExtentTest Child;
        private readonly ScenarioContext _scenarioContext;
        public static IWebDriver driver;
        public Runner(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Console.WriteLine("Scenario Name :" + _scenarioContext.ScenarioInfo.Title);
        }
        [BeforeFeature] //only once
        public void FrameworkIntialization()
        {
            //create Extent object here
            ParentTest = CreateParentTest("APSRTC", "Basic flows of APSRTC website ");
            driver = new DriverSetUp().BringDriver();
        }
        [BeforeScenario]  // executed before each scenario
        public void ScenarioIntilization()
        {
            //create child and add child here
           Child = CreateChild(ParentTest,_scenarioContext.ScenarioInfo.Title);
        }

        [AfterFeature]
        public void FrameworkCleanUp()
        {
            Extent.EndTest(ParentTest);
            Extent.Flush();
            Extent.Close();
        }

    }
}
