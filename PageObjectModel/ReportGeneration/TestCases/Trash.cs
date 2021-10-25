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
    public class Trash
    {
        public TestContext TestContext { get; set; }
        private static TestContext _testContext;
        private static ExtentTest child;
      //  [ClassInitialize]
        //public static void SetupTests(TestContext testContext)
        //{
        //    _testContext = testContext;
        //}
        [TestInitialize]
        public void SetupTest()
        {
            Console.WriteLine(TestContext.TestName,_testContext.TestName);
            child = ExtentLibrary.CreateChild(Reporter.extent, Reporter.parent, _testContext.TestName);
        }

        [TestCategory("Smoke")]
        [TestMethod]
        public void SeeTrashMails1()
        {
            Console.WriteLine("See the Trash Email1");
            ExtentLibrary.LogReport(true, child, "SeeTrashMails1");
        }
        [TestMethod]
        public void SeeTrashMails2()
        {
            Console.WriteLine("See the Trash Email2");
            ExtentLibrary.LogReport(true, child, "SeeTrashMails2");
        }
        [TestMethod]
        public void SeeTrashMails3()
        {
            Console.WriteLine("See the Trash Email3");
            ExtentLibrary.LogReport(true, child, "SeeTrashMails3");
        }
    }
}
