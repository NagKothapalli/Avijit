using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.AppControls
{
    public class ButtonControl : AppBaseControl
    {
        public string command;
        public ButtonControl(string command)
        {
            this.command = command; 
        }

        public void Click()
        {
            //run command
        }
    }
}
