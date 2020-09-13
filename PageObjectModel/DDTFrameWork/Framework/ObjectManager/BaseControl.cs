using DDTFrameWork.App.TestingTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework.ObjectManager
{
    public class BaseControl
    {
        AppiumWebElement appiumWebElement;
        IWebDriver webDriver = WebSuites.webDriver;
        IWebElement webElement ;

        public void FindObject()
        {

        }
        public void ClearText()
        {

        }
        public AppiumWebElement GetAppObject()
        {
            return appiumWebElement;
        }
        public IWebElement GetWebObject()
        {
            return webElement;
        }
        public IWebElement GetWebObject(string xpath)
        {
            return webDriver.FindElement(By.XPath(xpath));
        }
    }

   
}
