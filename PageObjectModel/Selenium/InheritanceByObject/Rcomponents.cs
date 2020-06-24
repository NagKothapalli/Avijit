using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByObject
{
    public class Rcomponents
    {
        public Rcomponents()
        {
            Debug.WriteLine("Open default browser : chrome ");
        }
        public Rcomponents(String browser)
        {
            //if browser = chrome then open chrome browser
            Debug.WriteLine("Open default browser : "+browser);
        }
        public Rcomponents(String browser,int version)
        {
            //if browser = chrome then open chrome browser
            Debug.WriteLine("Open default browser : " + browser + " - Version : " + version);
        }
        //*******************Reusable Components ************************
        public void LaunchApplication()
        {
            //open chrome browser
            Debug.WriteLine("RC : Launch Application");
        }
        public void LoginToApplication()
        {
            Debug.WriteLine("RC : Login To Application");
        }
        public void LogoutFromApplication()
        {
            Debug.WriteLine("RC : Logout From Application");
        }
        public void CloseApplication()
        {
            Debug.WriteLine("RC : Close Application");
        }
        public void Compose()
        {
            Debug.WriteLine("RC : Compose Mail");
        }
        public void Send()
        {
            Debug.WriteLine("RC : Send Mail");
        }
        public void Open()
        {
            Debug.WriteLine("RC : Open Mail");
        }
        public void Reply()
        {
            Debug.WriteLine("RC : Reply Mail");
        }
        public void Forward()
        {
            Debug.WriteLine("RC : Forward Mail");
        }
        public void Delete()
        {
            Debug.WriteLine("RC : Delete Mail");
        }
    }
}
