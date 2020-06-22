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
    public class GmailWithMsTest
    {
        //******************Test Suites ***********************
        [TestMethod]
        public void SmokeSuite()
        {
            Debug.WriteLine("Test Suite : Smoke");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
        }
        [TestMethod]
        public void RegressionSuite()
        {
            Debug.WriteLine("Test Suite : Regression");
            ComposeAndSendAnEmail();
            ReplyToAnEmail();
            ForwardAnEmail();
            DeleteAnEmail();
        }

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
        //*******************Reusable Components ************************
        public void LaunchApplication()
        {
            Debug.WriteLine("RC : Launch Application");
        }
        private void LoginToApplication()
        {
            Debug.WriteLine("RC : Login To Application");
        }
        protected void LogoutFromApplication()
        {
            Debug.WriteLine("RC : Logout From Application");
        }
        public void CloseApplication()
        {
            Debug.WriteLine("RC : Close Application");
        }
        public void Compose()
        {
            Debug.WriteLine("RC : Compose Mail");
        }
        private void Send()
        {
            Debug.WriteLine("RC : Send Mail");
        }
        public void Open()
        {
            Debug.WriteLine("RC : Open Mail");
        }
        public void Reply()
        {
            Debug.WriteLine("RC : Reply Mail");
        }
        public void Forward()
        {
            Debug.WriteLine("RC : Forward Mail");
        }
        public void Delete()
        {
            Debug.WriteLine("RC : Delete Mail");
        }
    }
}
