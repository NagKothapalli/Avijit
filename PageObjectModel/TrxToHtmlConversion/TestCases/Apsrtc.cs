using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxToHtmlConversion.TestCases
{
    [TestClass]
    public class Apsrtc
    {
       // [TestMethod, TestCategory("Smoke")]
        [TestMethod]
        [TestCategory("Smoke")]
        public void BookTicket()
        {
            Console.WriteLine("Test Case : Book Ticket");
        }
        [TestMethod, TestCategory("Smoke")]
        public void CancelTicket()
        {
            Console.WriteLine("Test Case : Cancel Ticket");
        }
        [TestMethod, TestCategory("Smoke")]
        public void TrackTicket()
        {
            Console.WriteLine("Test Case : Track Ticket");
        }
        [TestMethod, TestCategory("Smoke")]
        public void LinkTicket()
        {
            Console.WriteLine("Test Case : Link Ticket");
        }
    }
}
