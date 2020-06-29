using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Calculator
{
    public class ScientificCalc : IArithematicOperations,ITrigonametricOperations
    {
        //Imagine this class defined 200 functions
        public void DisplayScientificLogo()
        {
            Debug.WriteLine("Welcome Casio Scientific");
        }
        public int Addition(int a, int b)
        {
            Debug.WriteLine("Addition is from Scientificalc");
            return (a + b);
        }

        public int Division(int a, int b)
        {
            return (a / b);
        }

        public int Multiplication(int a, int b)
        {
            return (a * b);
        }

        public int Subtraction(int a, int b)
        {
            return (a - b);
        }

        public void Sine()
        {
            Debug.WriteLine("Sine Value");
        }

        public void CoSine()
        {
            Debug.WriteLine("CoSine Value");
        }

        public void CoSee()
        {
            Debug.WriteLine("CoSee Value");
        }
    }
}
