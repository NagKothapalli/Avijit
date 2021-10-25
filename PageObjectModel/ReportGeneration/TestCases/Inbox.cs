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
    public class Inbox
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
        [TestCategory("Smoke")]
        [TestMethod]
        public void ComposeEmail1()
        {
            Console.WriteLine("Compose An Email Send1");
            ExtentLibrary.LogReport(true, child, "ComposeEmail1");
        }
        [TestMethod]
        public void ComposeEmail2()
        {
            Console.WriteLine("Compose An Email Send2");
            ExtentLibrary.LogReport(true, child, "ComposeEmail2");
        }
        [TestMethod]
        public void ComposeEmail3()
        {
            Console.WriteLine("Compose An Email Send3");
            ExtentLibrary.LogReport(true, child, "ComposeEmail3");
        }

    }
}
