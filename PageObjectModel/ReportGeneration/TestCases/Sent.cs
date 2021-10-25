using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using ReportGeneration.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration.TestCases
{
    [TestClass]
    public class Sent
    {
        public TestContext TestContext { get; set; }
        private static TestContext _testContext;
        private static ExtentTest child;
        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }
        [TestInitialize]
        public void SetupTest()
        {
            Console.WriteLine(TestContext.TestName, _testContext.TestName);
            child = ExtentLibrary.CreateChild(Reporter.extent, Reporter.parent, _testContext.TestName);
        }
        [TestMethod]
        public void SeeSentMails1()
        {
            Console.WriteLine("See the sent Email1");
            ExtentLibrary.LogReport(true, child, "SeeSentMails1");
        }
        [TestCategory("Smoke")]
        [TestMethod]
        public void SeeSentMails2()
        {
            Console.WriteLine("See the sent Email2");
            ExtentLibrary.LogReport(true, child, "SeeSentMails2");
        }
        [TestMethod]
        public void SeeSentMails3()
        {
            Console.WriteLine("See the sent Email3");
            ExtentLibrary.LogReport(true, child, "SeeSentMails3");
        }
    }
}
