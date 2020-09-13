using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework.ObjectManager
{
    public class ButtonControl:BaseControl
    {

        public string selector;
        public ButtonControl(string selector)
        {
            this.selector = selector;
        }
        public void Click()
        {
            GetWebObject(selector).Click();
        }
    }
}
