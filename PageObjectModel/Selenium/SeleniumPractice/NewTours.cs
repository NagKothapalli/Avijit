using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice
{
    [TestClass]
    public class NewTours
    {
        IWebDriver driver = new ChromeDriver();
        public void LaunchApplication()
        {
            Debug.WriteLine("RC : Launch Application");
            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");
        }
        //id,name,class,cssSelector,linkText,partialLinkText,tagname,xpath
        [TestMethod]
        public void NewUserRegistration()
        {
            LaunchApplication();
            driver.FindElement(By.LinkText("REGISTER")).Click();
            driver.FindElement(By.Name("firstName")).SendKeys("John");
            driver.FindElement(By.Name("lastName")).SendKeys("David");
            driver.FindElement(By.Name("phone")).SendKeys("2342345467");
        }
    }
}
