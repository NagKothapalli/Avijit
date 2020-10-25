using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.AppControls
{
    public class LoginPageObject : LoginControls
    {
        public void Login(){
            UserNameField.Set("username");
            UserNameField.Clear();
            UserNameField.GetText();
            PassWordField.Set("password");
            SubmitButton.Click();
        }
        public void Login(string un,string pw){
            UserNameField.Set(un);
            UserNameField.Clear();
            UserNameField.GetText();
            PassWordField.Set(pw);
            SubmitButton.Click();
        }
    }
}
