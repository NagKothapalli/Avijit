using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageObjectModel.AppUtils;
using PageObjectModel.GeneralUtils;
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
   // [TestClass]
    public class TestCases : ReportGenarator
    {
        public IWebDriver driver; //null
        Login login;
        Inbox inbox;
        ExtentTest child;
        public static ExtentReports extent;
        public static ExtentTest parentTest;
        public TestCases()
        {
            driver = new DriverSetUp().BringDriver();
            login = new Login(driver);
            inbox = new Inbox(driver);
        }

        [TestMethod]
        public void MyTestCaseOne()
        {
            login.LaunchApplication();
            //login.LaunchApplication("https://gmail.com");
            login.LoginToApplication();
            inbox.Compose();
            inbox.Send();
            login.LogoutFromApplication();
        }
        Boolean result;
        //[TestInitialize]
        //public void IntializeReports()
        //{
        //   extent = new ExtentReports(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Reports\\IndividualReports" + new Random().Next(9999) + ".html");
        //}
        //Inbox - 
        [TestMethod] //Test Case / Test Scenario
        public void ComposeAndSendAnEmail()
        {
            try
            {
                child = CreateChild("Compose And Send An Email");
                Debug.WriteLine("Test Case : Compose and Send An Email");
                result = login.LaunchApplication();
                LogReport(result, child, "Launch", "User is able to Launch");
                result = login.LoginToApplication();
                LogReport(result, child, "Login","User is able to Login");
                result = inbox.Compose();
                LogReport(result, child, "Compose");
                result = inbox.Send();
                LogReport(result, child, "Send");
                result = login.LogoutFromApplication();
                LogReport(result, child, "Logout");
            }
            catch(Exception e)
            {
                child.Log(LogStatus.Fail, e);
            }
            //child = extent.StartTest("Compose And Send An Email");
            
            //extent.EndTest(mySmoke);

        }
        [TestMethod]
        public void ReplyToAnEmail()
        {
            //child = TestSuites.extent.StartTest("Reply To An Email");
            //TestSuites.parentTest.AppendChild(child);
            child = CreateChild("Reply To An Email");
            Debug.WriteLine("Test Case :Reply To An Email");
            LogReport(login.LaunchApplication(), child, "Launch");
            LogReport(login.LoginToApplication(), child, "Login");
            LogReport(inbox.Open(), child, "Open");
            LogReport(inbox.Reply(), child, "Reply");
            LogReport(login.LogoutFromApplication(), child, "Logout");
        }
        [TestMethod]
        public void ForwardAnEmail()
        {
            //child = TestSuites.extent.StartTest("Forward An Email");
            //TestSuites.parentTest.AppendChild(child);
            child = CreateChild("Forward An Email");
            Debug.WriteLine("Test Case :Forward An Email");
            LogReport(login.LaunchApplication(), child, "Launch");
            LogReport(login.LoginToApplication(), child, "Login");
            LogReport(inbox.Open(), child, "Open");
            LogReport(inbox.Forward(), child, "Forward");
            LogReport(login.LogoutFromApplication(), child, "Logout");
        }
        [TestMethod]
        public void DeleteAnEmail()
        {
            //child = TestSuites.extent.StartTest("Delete An Email");
            //TestSuites.parentTest.AppendChild(child);
            child = CreateChild("Delete An Email");
            Debug.WriteLine("Test Case :Delete An Email");
            LogReport(login.LaunchApplication(), child, "Launch");
            LogReport(login.LoginToApplication(), child, "Login");
            LogReport(inbox.Open(), child, "Open");
            LogReport(inbox.Delete(), child, "Delete");
            LogReport(login.LogoutFromApplication(), child, "Logout");
        }
       
        [TestCleanup]
        public void postEvents()
        {
            Debug.WriteLine("Post Events");
            //driver.Quit();
            extent.EndTest(child);
            extent.Flush();
            extent.Close();
        }
    }
}
