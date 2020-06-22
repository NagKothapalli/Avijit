using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByExtends
{
   // [TestClass]
    public class TestCases:ReusableComponents
    {
        //*************************Test Cases **********************
        [TestMethod]
        public void ComposeAndSendAnEmail()
        {
            Debug.WriteLine("Test Case : ComposeAndSendAnEmail");
            LaunchApplication();
            LoginToApplication();
            Compose();
            Send();
            LogoutFromApplication();
            CloseApplication();
        }
        [TestMethod]
        public void ReplyToAnEmail()
        {
            Debug.WriteLine("Test Case : ReplyToAnEmail");
            LaunchApplication();
            LoginToApplication();
            Open();
            Reply();
            LogoutFromApplication();
            CloseApplication();
        }
        [TestMethod]
        public void ForwardAnEmail()
        {
            Debug.WriteLine("Test Case : ForwardAnEmail");
            LaunchApplication();
            LoginToApplication();
            Open();
            Forward();
            LogoutFromApplication();
            CloseApplication();
        }
        [TestMethod]
        public void DeleteAnEmail()
        {
            Debug.WriteLine("Test Case : DeleteAnEmail");
            LaunchApplication();
            LoginToApplication();
            Open();
            Delete();
            LogoutFromApplication();
            CloseApplication();
        }
    }
}
