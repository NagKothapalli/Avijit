using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDTFrameWork.Framework.ReadJosn_Config;

namespace DDTFrameWork.Framework
{
    public class TestSetUp
    {
        public static AppiumDriver<AppiumWebElement> appiumDriver ;
        public static IWebDriver webDriver;
        public static DriverOptions driverOptions;
        public static AppRunSettings appConfigData;
        public static WebRunSettings webConfigData;
        public static AppiumDriver<AppiumWebElement> GetAppiumDriver()
        {
            //yet to implement the device connection
            appConfigData = new ReadJosn_Config().GetTestConfig().appRunSttings;
            //appConfigData.DeviceType
            //appConfigData.IPAddress
            appiumDriver = new AndroidDriver<AppiumWebElement>(new Uri(""), driverOptions);
            return appiumDriver;
        }

        public static IWebDriver GetWebDriver()
        {
            //yet to implement remote driver
            webConfigData = new ReadJosn_Config().GetTestConfig().webRunSttings;
            if(webConfigData.Browser.ToLower().Equals("chrome"))
            {
                webDriver = new ChromeDriver();
            }
            else
            {
                webDriver = new FirefoxDriver();
            }
            
            return webDriver;
        }

    }
}
