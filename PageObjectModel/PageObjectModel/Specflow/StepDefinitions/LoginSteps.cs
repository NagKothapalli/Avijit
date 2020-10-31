using OpenQA.Selenium;
using PageObjectModel.GeneralUtils;
using PageObjectModel.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PageObjectModel.Specflow.StepDefinitions
{
   [Binding]
    public sealed class LoginSteps : ReportGenarator
    {
        private readonly ScenarioContext _scenarioContext;
        public Login login;
        //public IWebDriver driver;
        public Boolean result;
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Console.WriteLine("Scenario Name :" + _scenarioContext.ScenarioInfo.Title);
            login = new Login(Runner.driver);
        }


        [Given(@"I Launch Apsrtc website")]
        public void GivenILaunchApsrtcWebsite()
        {
            result = login.LaunchApplication();
            LogReport(result, Runner.Child, "Launch Application");
        }

        [When(@"I Logged in to the website")]
        public void WhenILoggedInToTheWebsite()
        {
            result = login.LoginToApplication();
        }

        [Given(@"I Launch Apsrtc website ""(.*)""")]
        public void GivenILaunchApsrtcWebsite(string AppUrl)
        {
            login.LaunchApplication(AppUrl);
        }



    }
}
