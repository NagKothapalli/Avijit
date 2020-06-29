using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Calculator
{
    public class MiniCalc:IArithematicOperations
    {
        public void DisplayMiniLogo()
        {
            Debug.WriteLine("Welcome Casio Mini");
        }
        public int Addition(int a,int b)
        {
            Debug.WriteLine("Addition is from MiniCalc");
            return a + b;
        }
        public int Subtraction(int a, int b)
        {
            return a - b;
        }
        public int Multiplication(int a, int b)
        {
            return a * b;
            
        }
        public int Division(int a, int b)
        {
            return a / b;
        }
    }
}
