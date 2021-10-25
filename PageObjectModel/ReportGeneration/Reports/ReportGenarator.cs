using OpenQA.Selenium;

using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.GeneralUtils
{
    public class ReportGenarator
    {
        
        public IWebDriver driver;
        public ExtentTest child;
        public ExtentTest CreateParentTest(string parentName, string description)
        {
            ExtentReports extent = new ExtentReports(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Reports\\" + parentName + "-" + new Random().Next(9999) + ".html");
            ExtentTest parentTest = extent.StartTest(parentName, description);
            return parentTest;
        }
        public ExtentTest CreateChild(ExtentTest parentTest, string childName)
        {           
            //ExtentTest child = Runner.Extent.StartTest(childName);
            parentTest.AppendChild(child);           
            return child;
        }
        public ExtentTest CreateChild( string childName)
        {
           // ExtentTest child = Runner.Extent.StartTest(childName);
            //parentTest.AppendChild(child);
            return child;
        }
        public void LogReport(Boolean result, ExtentTest test, String stepName)
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
        string screenshotfilepath;
        public String TakeErrorScreenShot(String fname)
        {
           // Screenshot scrFile = ((ITakesScreenshot)Runner.driver).GetScreenshot();
            string screenshotfilepath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\ScreenShots\\" + fname + "-" + new Random().Next(9999);
           // scrFile.SaveAsFile(screenshotfilepath);
            return screenshotfilepath;
        }
        public String TakeErrorScreenShot(IWebDriver driver,String fname)
        {
            Screenshot scrFile = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotfilepath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\ScreenShots\\" + fname + "-" + new Random().Next(9999);
            scrFile.SaveAsFile(screenshotfilepath);
            return screenshotfilepath;
        }

    }
}
