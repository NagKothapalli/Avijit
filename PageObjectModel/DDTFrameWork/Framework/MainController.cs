using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    [TestClass]
    public class TestSuites
    {
        public static IWebDriver webDriver;
        public static AppiumDriver<AppiumWebElement> appDriver ;
        [TestInitialize]
        public void BeforeTestRun()
        {
            webDriver = TestSetUp.GetWebDriver();
            appDriver = TestSetUp.GetAppiumDriver();
        }

    }
}
