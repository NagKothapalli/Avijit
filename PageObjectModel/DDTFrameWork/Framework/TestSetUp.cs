using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    public class TestSetUp
    {
        public static AppiumDriver<AppiumWebElement> appiumDriver ;
        public static IWebDriver webDriver;
        public static DriverOptions driverOptions;
       
        public static AppiumDriver<AppiumWebElement> GetAppiumDriver()
        {
            appiumDriver = new AndroidDriver<AppiumWebElement>(new Uri(""), driverOptions);
            return appiumDriver;
        }

        public static IWebDriver GetWebDriver()
        {
            webDriver =  new ChromeDriver();
            return webDriver;
        }

    }
}
