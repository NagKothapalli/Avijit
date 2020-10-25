using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.AppControls
{
    public class LoginControls
    {
        public TextBoxControl UserNameField;
        public TextBoxControl PassWordField;
        public ButtonControl SubmitButton;
        public LoginControls()
        {
            UserNameField = new TextBoxControl("username-command");
            PassWordField = new TextBoxControl("password-command");
            SubmitButton = new ButtonControl("button-command");
        }
    }
}
