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
        public static ExtentReports extent;
        public static ExtentTest parentTest;
        public TestCases()
        {
            driver = new DriverSetUp().BringDriver();
            login = new Login(driver);
            inbox = new Inbox(driver);
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
                logReport(result, child, "Launch", "User is able to Launch");
                result = login.LoginToApplication();
                logReport(result, child, "Login","User is able to Login");
                result = inbox.Compose();
                logReport(result, child, "Compose");
                result = inbox.Send();
                logReport(result, child, "Send");
                result = login.LogoutFromApplication();
                logReport(result, child, "Logout");
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
            logReport(login.LaunchApplication(), child, "Launch");
            logReport(login.LoginToApplication(), child, "Login");
            logReport(inbox.Open(), child, "Open");
            logReport(inbox.Reply(), child, "Reply");
            logReport(login.LogoutFromApplication(), child, "Logout");
        }
        [TestMethod]
        public void ForwardAnEmail()
        {
            //child = TestSuites.extent.StartTest("Forward An Email");
            //TestSuites.parentTest.AppendChild(child);
            child = CreateChild("Forward An Email");
            Debug.WriteLine("Test Case :Forward An Email");
            logReport(login.LaunchApplication(), child, "Launch");
            logReport(login.LoginToApplication(), child, "Login");
            logReport(inbox.Open(), child, "Open");
            logReport(inbox.Forward(), child, "Forward");
            logReport(login.LogoutFromApplication(), child, "Logout");
        }
        [TestMethod]
        public void DeleteAnEmail()
        {
            //child = TestSuites.extent.StartTest("Delete An Email");
            //TestSuites.parentTest.AppendChild(child);
            child = CreateChild("Delete An Email");
            Debug.WriteLine("Test Case :Delete An Email");
            logReport(login.LaunchApplication(), child, "Launch");
            logReport(login.LoginToApplication(), child, "Login");
            logReport(inbox.Open(), child, "Open");
            logReport(inbox.Delete(), child, "Delete");
            logReport(login.LogoutFromApplication(), child, "Logout");
        }
        public ExtentTest CreateChild(string childName)
        {
            try{
                child = TestSuites.extent.StartTest(childName);
                TestSuites.parentTest.AppendChild(child);
            }catch (Exception e){
                extent = new ExtentReports(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Reports\\"+childName+"-" + new Random().Next(9999) + ".html");
                child = extent.StartTest(childName);
            }
            return child;
        }
        public void logReport(Boolean result, ExtentTest test, String stepName)
        {
            if (result == true)
                test.Log(LogStatus.Pass, stepName , "- is successfull");
            else
            {
                //imageFile = CaptureScreenShot();
                test.Log(LogStatus.Fail, test.AddScreenCapture(TakeErrorScreenShot(stepName)) + stepName + " - is Failed");
            }
                
        }
        public void logReport(Boolean result, ExtentTest test, String stepName,String details)
        {
            if (result == true)
                test.Log(LogStatus.Pass, stepName, details);
            else
            {
                //imageFile = CaptureScreenShot();
                test.Log(LogStatus.Fail, test.AddScreenCapture(TakeErrorScreenShot(stepName)) + stepName + " - is Failed");
            }

        }
        string screenshotfilepath;
        public String TakeErrorScreenShot(String fname)
        {
            Screenshot scrFile = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotfilepath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\ScreenShots\\" + fname + "-" + new Random().Next(9999);
            scrFile.SaveAsFile(screenshotfilepath);
            return screenshotfilepath;
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
