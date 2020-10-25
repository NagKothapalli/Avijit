using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.AppControls
{
    public class TextBoxControl : AppBaseControl
    {
        string command;
        public TextBoxControl(string command)
        {
            this.command = command;
        }

        public void Set(string text)
        {
            //run command
        }
        public void Clear()
        {
            //run command
        }
    }
}
