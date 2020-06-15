using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByExtends
{
    [TestClass]
    public class MyExecutionReport
    {
        [TestMethod]
        public void ComposeAndSendAnEmail()
        {
            ExtentReports extent = new ExtentReports(@"D:\WorkSpace\CsharpGit\PageObjectModel\Selenium\Reports\AvijitReports2.html");
            ExtentTest mySmoke = extent.StartTest("Smoke Test","This for my Build Validation");
            string myDir = AppDomain.CurrentDomain.BaseDirectory;
            Debug.WriteLine("Base Directory :" +myDir );
            Debug.WriteLine("Current Directory :" + Environment.CurrentDirectory);
            //Launch - is successfull
            mySmoke.Log(LogStatus.Pass, "Launch - is successfull");//Log Report
            //Login - is successfull
            mySmoke.Log(LogStatus.Pass, "Login - is successfull");//Log Report
            //Compose - is successfull
            mySmoke.Log(LogStatus.Pass, "Compose - is successfull");//Log Report
            //Send - is successfull
            mySmoke.Log(LogStatus.Fail, "Send - is successfull");//Log Report
            //Logout - is successfull
            mySmoke.Log(LogStatus.Info, "Logout - is successfull");//Log Report
            //Close - is successfull
            mySmoke.Log(LogStatus.Pass, "Close - is successfull");//Log Report
            extent.EndTest(mySmoke);
            extent.Flush();
            extent.Close();

        }
    }
}
