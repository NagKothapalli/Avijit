using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.PageObjects
{
    public class Inbox
    {
        IWebDriver driver;
        public Inbox(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Compose()
        {
            Debug.WriteLine("RC : Compose");
        }
        public void Send()
        {
            Debug.WriteLine("RC : Send");
        }
        public void Open()
        {
            Debug.WriteLine("RC : Open Mail");
        }
        public void Reply()
        {
            Debug.WriteLine("RC : Reply to Mail");
        }
    }
}
