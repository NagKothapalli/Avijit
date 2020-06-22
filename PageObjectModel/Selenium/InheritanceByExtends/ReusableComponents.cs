using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByExtends
{
    public class ReusableComponents
    {       
        //*******************Reusable Components ************************
        public void LaunchApplication()
        {
            Debug.WriteLine("RC : Launch Application");
        }
        public void LoginToApplication()
        {
            Debug.WriteLine("RC : Login To Application");
        }
        protected void LogoutFromApplication()
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
