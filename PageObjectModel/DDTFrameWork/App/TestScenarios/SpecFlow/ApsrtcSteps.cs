using DDTFrameWork.App.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DDTFrameWork.App.TestScenarios.SpecFlow
{
    [Binding]
    public sealed class ApsrtcSteps
    {

        private readonly ScenarioContext _scenarioContext;
        Login login;
        public ApsrtcSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            login = new Login();
        }
        [Given(@"I Called APSRTC Website")]
        public void GivenICalledAPSRTCWebsite()
        {
            login.LaunchApplication();
        }

        [When(@"I Give the User Details like UserName and PassWord")]
        public void WhenIGiveTheUserDetailsLikeUserNameAndPassWord()
        {
            login.LoginToApplication();
        }

        [Then(@"I Should be Logged in Successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            login.VerifyUserLogin();
        }

        [When(@"I Give the User Details like ""(.*)"" and ""(.*)""")]
        public void WhenIGiveTheUserDetailsLikeAnd(string username, string password)
        {
            login.LoginToApplication(username, password);
        }


    }
}
