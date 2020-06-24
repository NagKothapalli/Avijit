using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByObject
{
    [TestClass]
    public class TestBatches
    {
        public TestScenarios tscenarios = new TestScenarios();
        //******************Test Suites ***********************
        [TestMethod]
        public void SmokeSuite()
        {
            Debug.WriteLine("Test Suite : Smoke");
            tscenarios.ComposeAndSendAnEmail();
            tscenarios.ReplyToAnEmail();
        }
        [TestMethod]
        public void RegressionSuite()
        {
            Debug.WriteLine("Test Suite : Regression");
            tscenarios.ComposeAndSendAnEmail();
            tscenarios.ReplyToAnEmail();
            tscenarios.ForwardAnEmail();
            tscenarios.DeleteAnEmail();
        }
    }
}
