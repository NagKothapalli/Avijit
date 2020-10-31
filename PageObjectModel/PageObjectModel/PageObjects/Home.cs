using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjectModel.PageObjects
{
    public class Home
    {
        IWebDriver driver;
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Boolean BookTicket()
        {
            IWebElement fromCity = driver.FindElement(By.XPath("//input[contains(@title,'Enter bording place name ')]"));
            fromCity.SendKeys("TIRUPATHI");
            //fromCity.SendKeys(gUtils.readValue("FromCity"));
            Thread.Sleep(1000);
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
            driver.FindElement(By.XPath("//input[@id='searchBtn']")).Click();
            driver.SwitchTo().Alert().Accept();
            IWebElement toCity = driver.FindElement(By.XPath("//input[contains(@title,'Enter alighting place')]"));
            toCity.SendKeys("GUNTUR");
            //toCity.SendKeys(gUtils.readValue("ToCity"));
            Thread.Sleep(1000);
            actions.SendKeys(Keys.Enter).Build().Perform();
            actions.SendKeys(Keys.Tab).Build().Perform();
            //Select the date
            driver.FindElement(By.XPath("//a[@class='ui-state-default' and text()='4']")).Click();            
            driver.FindElement(By.XPath("//input[@id='searchBtn']")).Click();
            return true;
        }
    }
}
