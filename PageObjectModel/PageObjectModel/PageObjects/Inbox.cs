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
        public Boolean Compose()
        {
            Debug.WriteLine("RC : Compose");
            return true;
        }
        public Boolean Send()
        {
            Debug.WriteLine("RC : Send");
            return true;
        }
        public Boolean Open()
        {
            Debug.WriteLine("RC : Open Mail");
            return true;
        }
        public Boolean Reply()
        {
            Debug.WriteLine("RC : Reply to Mail");
            return true;
        }
        public Boolean Forward()
        {
            Debug.WriteLine("RC : Forward Mail");
            return true;
        }
        public Boolean Delete()
        {
            Debug.WriteLine("RC : Delete Mail");
            return false;
        }
    }
}
