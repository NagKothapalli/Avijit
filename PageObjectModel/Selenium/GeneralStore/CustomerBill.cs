using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Calculator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.GeneralStore
{
    [TestClass]
    public class CustomerBill
    {
        [TestMethod]
        public void PrintCustomerBill()
        {
            int prod1 = 3434324;
            int prod2 = 5645434;
            MiniCalc mCalc = new MiniCalc();
            CommercialCalc cCalc = new CommercialCalc();
            ScientificCalc sCalc = new ScientificCalc();
            IArithematicOperations calc = new ScientificCalc();
            ITrigonametricOperations Tcalc = new ScientificCalc();
            //IWebDriver driver = new ChromeDriver();
            int bill = sCalc.Addition(prod1,prod2);
            Debug.WriteLine("Customer Bill :" + bill);
            //mCalc.DisplayMiniLogo();
            //cCalc.DisplayCommercialLogo();
            sCalc.DisplayScientificLogo();
            calc.Addition(prod1,prod2);
            Tcalc.CoSee();
        }
    }
}
