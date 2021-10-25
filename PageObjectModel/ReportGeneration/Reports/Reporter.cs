using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration.Reports
{
    [TestClass]
    public class Reporter : ExtentLibrary
    {
        public static ExtentReports extent;
        public static ExtentTest parent;
        [AssemblyInitialize]
        public static void StartReporting(TestContext tc)
        {
            Console.WriteLine("Create HTML and start reporting");
            extent = CreateExtent("ScopeAR","ScopeAR Mobile Automation Test Results");
            parent = CreateParentTest(extent,"ScopeAR", "ScopeAR Mobile Automation Test Results");
        }
        [AssemblyCleanup]
        public static void EndReport()
        {
            extent.EndTest(parent);
            extent.Flush();
            extent.Close();
        }

       

    }
}

