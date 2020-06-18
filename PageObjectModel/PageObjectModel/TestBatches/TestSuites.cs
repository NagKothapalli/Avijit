using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectModel.TestScenarios;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.TestBatches
{
    [TestClass]
    public class TestSuites:TestCases
    {
        public static ExtentReports extent;
        public static ExtentTest parentTest;
        string root;
        public TestSuites()
        {
            //root = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            //int ranNum = new Random().Next(9999);
            //extent = new ExtentReports(root+"\\Reports\\POMReports"+ranNum+".html");
            //extent = new ExtentReports(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Reports\\POMReports" + new Random().Next(9999) + ".html");

        }

        public void CreateParentTest(string parentName,string description)
        {
            extent = new ExtentReports(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Reports\\"+ parentName+"-" + new Random().Next(9999) + ".html");
            parentTest = extent.StartTest(parentName, description);
        }
        //Smoke ->Constructor -extent object ->In to Smoke - parentTest object
       [TestMethod]
       public void SmokeSuite()
       {
            CreateParentTest("SmokeSuite", "This for my Build Validation");
            Debug.WriteLine("Test Suite : SMOKE");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
       }
        [TestMethod]
       public void RegressionSuite()
       {
            //parentTest = extent.StartTest("Regression Test", "This is for my Full Cycle Testing");
            CreateParentTest("RegressionSuite", "This is for my Full Cycle Testing");
            Debug.WriteLine("Test Suite : SMOKE");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
            ForwardAnEmail();
            DeleteAnEmail();

        }
        [TestCleanup]
        public void postEvents()
        {
            Debug.WriteLine("Post Events");
            //driver.Quit();
            extent.EndTest(parentTest);
            extent.Flush();
            extent.Close();
        }
    }
}
