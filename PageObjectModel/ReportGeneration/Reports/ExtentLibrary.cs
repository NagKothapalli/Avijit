using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration.Reports
{
    public class ExtentLibrary
    {
        public static ExtentReports CreateExtent(string parentName, string description)
        {
            return new ExtentReports(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Reports\\" + parentName + "-" + new Random().Next(9999) + ".html");            
           
        }
        public static ExtentTest CreateParentTest(ExtentReports extent , string parentName, string description)
        {
            return extent.StartTest(parentName, description);
        }
        public static ExtentTest CreateChild(ExtentReports extent,ExtentTest parentTest, string childName)
        {
            ExtentTest child = extent.StartTest(childName);
            parentTest.AppendChild(child);
            return child;
        }
        //public ExtentTest CreateChild(ExtentReports extent , ExtentTest parent,string childName)
        //{
        //    ExtentTest child = extent.StartTest(childName);
        //    parent.AppendChild(child);
        //    return child;
        //}
        public static void LogReport(Boolean result, ExtentTest test, String stepName)
        {
            if (result == true)
                test.Log(LogStatus.Pass, stepName, "- is successfull");
            else
            {
                //imageFile = CaptureScreenShot();
                test.Log(LogStatus.Fail, test.AddScreenCapture(TakeErrorScreenShot(stepName)) + stepName + " - is Failed");
            }

        }
        public void LogReport(Boolean result, ExtentTest test, String stepName, String details)
        {
            if (result == true)
                test.Log(LogStatus.Pass, stepName, details);
            else
            {
                //imageFile = CaptureScreenShot();
                test.Log(LogStatus.Fail, test.AddScreenCapture(TakeErrorScreenShot(stepName)) + stepName + " - is Failed");
            }

        }
        static IWebDriver driver;
        static string screenshotfilepath;
        public static String TakeErrorScreenShot(String fname)
        {
            Screenshot scrFile = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotfilepath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\ScreenShots\\" + fname + "-" + new Random().Next(9999);
            scrFile.SaveAsFile(screenshotfilepath);
            return screenshotfilepath;
        }
        public String TakeErrorScreenShot(IWebDriver driver, String fname)
        {
            Screenshot scrFile = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotfilepath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\ScreenShots\\" + fname + "-" + new Random().Next(9999);
            scrFile.SaveAsFile(screenshotfilepath);
            return screenshotfilepath;
        }
    }
}
