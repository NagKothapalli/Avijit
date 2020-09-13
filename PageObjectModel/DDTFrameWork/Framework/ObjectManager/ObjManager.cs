using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework.ObjectManager
{

    public class ObjManager : ReadJosn_Data
    {
        public TextBoxControl TextBoxControl(string xpath)
        {
            TextBoxControl tb = new TextBoxControl(xpath);
            return tb;
        }
        public ButtonControl ButtonControl(string xpath)
        {
            ButtonControl btn = new ButtonControl(xpath);
            return btn;
        }
    }
}
