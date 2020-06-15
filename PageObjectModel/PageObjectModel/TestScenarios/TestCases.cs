using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageObjectModel.AppUtils;
using PageObjectModel.PageObjects;
using RelevantCodes.ExtentReports;
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
        ExtentReports extent;
        public TestCases()
        {
            driver = new DriverSetUp().BringDriver();
            login = new Login(driver);
            inbox = new Inbox(driver);
        }
        Boolean result;
        //Inbox - 
        [TestMethod] //Test Case / Test Scenario
        public void ComposeAndSendAnEmail()
        {
            extent = new ExtentReports(@"D:\WorkSpace\CsharpGit\PageObjectModel\PageObjectModel\Reports\POMReports.html");
            ExtentTest mySmoke = extent.StartTest("Smoke Test", "This for my Build Validation");
            Debug.WriteLine("Test Case : Compose and Send An Email");
            result = login.LaunchApplication();
            if (result == true)
                mySmoke.Log(LogStatus.Pass, "Launch - is successfull");
            else
                mySmoke.Log(LogStatus.Fail, "Launch - is Failed");
            login.LoginToApplication();
            mySmoke.Log(LogStatus.Pass, "Login - is successfull");
            inbox.Compose();
            mySmoke.Log(LogStatus.Pass, "Compose - is successfull");
            inbox.Send();
            mySmoke.Log(LogStatus.Pass, "Send - is successfull");
            login.LogoutFromApplication();
            mySmoke.Log(LogStatus.Pass, "Logout - is successfull");
            extent.EndTest(mySmoke);
            
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
        [TestCleanup]
        public void postEvents()
        {
            Debug.WriteLine("Post Events");
            extent.Flush();
            extent.Close();
        }
    }
}
