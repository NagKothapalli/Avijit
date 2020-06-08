using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.AppUtils
{
    public class DriverSetUp
    {
        //This is a class which will give the user specific web driver object
        IWebDriver driver;
        public IWebDriver BringDriver()
        {
           string browser = ConfigurationManager.AppSettings["Browser"];
           if(browser.Equals("chrome"))
           {
                driver = new ChromeDriver();
           }
           else if (browser.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (browser.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
           else
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
    }
}
