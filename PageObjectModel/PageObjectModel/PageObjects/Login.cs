using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjectModel.PageObjects
{
    public class Login
    {
        IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void LaunchApplication()
        {
            Debug.WriteLine("RC : Launch Application");
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }
        public void LoginToApplication()
        {
            Debug.WriteLine("RC : Login To Application");
            IWebElement userName = driver.FindElement(By.XPath("//input[@name='identifier']"));
            userName.SendKeys(ConfigurationManager.AppSettings["UserName"]);
            IWebElement nxtObj = driver.FindElement(By.XPath("//span[text()='Next']"));
            nxtObj.Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(ConfigurationManager.AppSettings["PassWord"]);
            driver.FindElement(By.XPath("//span[text()='Next']")).Click();
        }
        public void LogoutFromApplication()
        {
            Debug.WriteLine("RC : Logout From Application");
            driver.Quit();
        }
    }
}
