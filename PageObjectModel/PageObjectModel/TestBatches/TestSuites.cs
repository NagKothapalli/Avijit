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
  // [TestClass]
    public class TestSuites:TestCases
    {
        public static ExtentReports extent;
        public static ExtentTest parentTest;
        string root;
        public TestSuites()
        {

        }
        //Smoke ->Constructor -extent object ->In to Smoke - parentTest object
       [TestMethod]
       public void SmokeSuite() //BVT
       {
            CreateParentTest("SmokeSuite", "This for my Build Validation");
            Debug.WriteLine("Test Suite : SMOKE");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
       }
        [TestMethod]
       public void RegressionSuite()
       {
            CreateParentTest("RegressionSuite", "This is for my Full Cycle Testing");
            Debug.WriteLine("Test Suite : SMOKE");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
            ForwardAnEmail();
            DeleteAnEmail();

        }
        [TestCleanup]
        public void PostEvents()
        {
            Debug.WriteLine("Post Events");
            extent.EndTest(parentTest);
            extent.Flush();
            extent.Close();
        }
    }
}
