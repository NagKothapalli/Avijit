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
        public TestSuites()
        {
            extent = new ExtentReports(@"D:\WorkSpace\CsharpGit\PageObjectModel\PageObjectModel\Reports\POMReports.html");
            
        }
        //Smoke ->Constructor -extent object ->In to Smoke - parentTest object
       [TestMethod]
       public void SmokeSuite()
       {
            parentTest = extent.StartTest("Smoke Test", "This for my Build Validation");
            Debug.WriteLine("Test Suite : SMOKE");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
       }
        [TestMethod]
       public void RegressionSuite()
       {
            parentTest = extent.StartTest("Regression Test", "This for my Full Cycle Testing");
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
