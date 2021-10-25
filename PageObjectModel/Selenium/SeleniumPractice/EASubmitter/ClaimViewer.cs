using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    [TestClass]
    public class ClaimViewer
    {
        public static IList<ServiceLineData> dataLines = new List<ServiceLineData>();
        public static IList<ServiceLineData> dataLinesAfter = new List<ServiceLineData>();

        public void AddServiceLines(int count)
        {
            for(int i=0;i<count;i++)
            {
               // dataLines.Add(new ServiceLineData("320", new Random().Next(99999).ToString(), "PO", "PO", "PO", "PO", "100"));
                Console.WriteLine(dataLines.ElementAt(i).HCMC);
                //Enter the values in to the table
            }
        }
        public void ReadServiceLines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string hcm = dataLines.ElementAt(i).HCMC.ToString();
                //int row = getrowwithcelltext();
                //string d = getcelldata(row,2);
               // dataLinesAfter.Add(new ServiceLineData("320", new Random().Next(99999).ToString(), "PO", "PO", "PO", "PO", "100"));
            }
        }
        public void VerifyDataLines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(dataLines.ElementAt(i).Number, dataLinesAfter.ElementAt(i).Number);
                Assert.AreEqual(dataLines.ElementAt(i).HCMC, dataLinesAfter.ElementAt(i).HCMC);
                Assert.AreEqual(dataLines.ElementAt(i).M1, dataLinesAfter.ElementAt(i).M1);
                Assert.AreEqual(dataLines.ElementAt(i).M2, dataLinesAfter.ElementAt(i).M2);
                Assert.AreEqual(dataLines.ElementAt(i).M3, dataLinesAfter.ElementAt(i).M3);
                Assert.AreEqual(dataLines.ElementAt(i).M4, dataLinesAfter.ElementAt(i).M4);
                Assert.AreEqual(dataLines.ElementAt(i).Amount, dataLinesAfter.ElementAt(i).Amount);
            }
        }
        [TestMethod]
        public void AddClaim()
        {
            AddServiceLines(2);
        }
    }
    public class ServiceLineData
    {
        public string Number { get; set; }
        public string HCMC { get; set; }
        public string M1 { get; set; }
        public string M2 { get; set; }
        public string M3 { get; set; }
        public string M4 { get; set; }
        public string Amount { get; set; }
        public string M5 { get; set; }
        public string M6 { get; set; }
        public ServiceLineData(string Number,string HCMC,string M1,string M2,string M3,string M4,string Amount,string m5,string m6)
        {
            this.Number = Number; this.HCMC = HCMC; this.M1 = M1;this.M2 = M2; this.M3 = M3; this.M4 = M4;this.Amount = Amount;
        }
    }

}
