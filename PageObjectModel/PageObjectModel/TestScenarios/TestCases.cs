using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageObjectModel.AppUtils;
using PageObjectModel.PageObjects;
using PageObjectModel.TestBatches;
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
        ExtentTest child;
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
            child = TestSuites.extent.StartTest("Compose And Send An Email");
            TestSuites.parentTest.AppendChild(child);
            Debug.WriteLine("Test Case : Compose and Send An Email");
            result = login.LaunchApplication();
            logReport(result,child,"Launch");
            result = login.LoginToApplication();
            logReport(result, child, "Login");
            result = inbox.Compose();
            logReport(result, child, "Compose");
            result = inbox.Send();
            logReport(result, child, "Send");
            result = login.LogoutFromApplication();
            logReport(result, child, "Logout");
            //extent.EndTest(mySmoke);

        }
       
        [TestMethod]
        public void ReplyToAnEmail()
        {
            child = TestSuites.extent.StartTest("Reply To An Email");
            TestSuites.parentTest.AppendChild(child);
            Debug.WriteLine("Test Case :Reply To An Email");
            logReport(login.LaunchApplication(), child, "Launch");
            logReport(login.LoginToApplication(), child, "Login");
            logReport(inbox.Open(), child, "Open");
            logReport(inbox.Reply(), child, "Reply");
            logReport(login.LogoutFromApplication(), child, "Logout");
        }
        public void ForwardAnEmail()
        {
            child = TestSuites.extent.StartTest("Forward An Email");
            TestSuites.parentTest.AppendChild(child);
            Debug.WriteLine("Test Case :Forward An Email");
            logReport(login.LaunchApplication(), child, "Launch");
            logReport(login.LoginToApplication(), child, "Login");
            logReport(inbox.Open(), child, "Open");
            logReport(inbox.Forward(), child, "Forward");
            logReport(login.LogoutFromApplication(), child, "Logout");
        }
        public void DeleteAnEmail()
        {
            child = TestSuites.extent.StartTest("Delete An Email");
            TestSuites.parentTest.AppendChild(child);
            Debug.WriteLine("Test Case :Delete An Email");
            logReport(login.LaunchApplication(), child, "Launch");
            logReport(login.LoginToApplication(), child, "Login");
            logReport(inbox.Open(), child, "Open");
            logReport(inbox.Delete(), child, "Delete");
            logReport(login.LogoutFromApplication(), child, "Logout");
        }
        public void logReport(Boolean result, ExtentTest test, String stepName)
        {
            if (result == true)
                test.Log(LogStatus.Pass, stepName + "- is successfull");
            else
                test.Log(LogStatus.Fail, stepName + "- is Failed");
        }

    }
}
