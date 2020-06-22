using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByExtends
{
    [TestClass]
    public class TestSuites:TestCases  // Extends
    {
        //******************Test Suites ***********************
        [TestMethod]
        public void SmokeSuite()
        {
            Debug.WriteLine("Test Suite : Smoke");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
        }
        [TestMethod]
        public void RegressionSuite()
        {
            Debug.WriteLine("Test Suite : Regression");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
            ForwardAnEmail();
            DeleteAnEmail();
        }
    }
}
