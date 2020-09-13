using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework.ObjectManager
{
    public class TextBoxControl:BaseControl
    {
        public string selector;
        public TextBoxControl(string selector)
        {
            this.selector = selector;
        }
        public void Set(string value)
        {
            GetWebObject(selector).SendKeys(value);
        }
        public void Clear(string value)
        {
            GetWebObject(selector).Clear();
        }
    }
}
