using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageObjectModel.AppUtils;
using PageObjectModel.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.TestScenarios
{   
    [TestClass]
    public class TestCases
    {
        public IWebDriver driver;
        Login login;
        Inbox inbox;
        public TestCases()
        {
            driver = new DriverSetUp().BringDriver();
            login = new Login(driver);
            inbox = new Inbox(driver);
        }
        //Inbox - 
        [TestMethod] //Test Case / Test Scenario
        public void ComposeAndSendAnEmail()
        {
            Debug.WriteLine("Test Case : Compose and Send An Email");
            login.LaunchApplication();
            login.LoginToApplication();
            inbox.Compose();
            inbox.Send();
            login.LogoutFromApplication();
        }
        [TestMethod]
        public void ReplyToAnEmail()
        {
            Debug.WriteLine("Test Case :Reply To An Email");
            login.LaunchApplication();
            login.LoginToApplication();
            inbox.Open();
            inbox.Reply();
            login.LogoutFromApplication();
        }
    }
}
