using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Calculator
{
    public class CommercialCalc:IArithematicOperations
    {
        public int Addition(int a, int b)
        {
            Debug.WriteLine("Addition is from CommercialCalc");
            int sum = a + b;
            return sum;
        }

        public void DisplayCommercialLogo()
        {
            Debug.WriteLine("Welcome Casio Commercial");
        }

        public int Division(int a, int b)
        {
            return a / b;
        }

        public int Multiplication(int a, int b)
        {
            return a * b;
        }

        public int Subtraction(int a, int b)
        {
            return a - b;
        }
    }
}
