using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework.ObjectManager
{
    public class TextBoxControl:BaseControl
    {
        public string xpath;
        public TextBoxControl(string xpath)
        {
            this.xpath = xpath;
        }
        public void Set(string value)
        {
            GetWebObject(xpath).SendKeys(value);
        }
        public void Clear(string value)
        {
            GetWebObject(xpath).Clear();
        }
    }
}
