using DDTFrameWork.App.TestScenarios;
using DDTFrameWork.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.App.TestingTypes
{
    [TestClass]
    public class WebSuites
    {
        public static IWebDriver webDriver { get; set; }
        public static AppiumDriver<AppiumWebElement> appDriver;
        public TestCases testCases;
        [TestInitialize]
        public void BeforeTestRun()
        {
            webDriver = TestSetUp.GetWebDriver();
            testCases = new TestCases();
            //appDriver = TestSetUp.GetAppiumDriver();
        }
        [TestMethod]
        public void SmokeSuite()
        {
            testCases.GmailLogin();
        }
    }
}
