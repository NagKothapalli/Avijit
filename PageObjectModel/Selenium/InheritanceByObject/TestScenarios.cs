using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByObject
{
    [TestClass]
    public class TestScenarios
    {
        //Modifier ClassName   objectName = new Constructor();
        //Constructor is a function without return type written inside a class and its name must be same as class name, 
        //public Rcomponents rcom = new Rcomponents();
        //public Rcomponents rcom = new Rcomponents("firefox");
        public Rcomponents rcom = new Rcomponents("firefox",65);
        //*************************Test Cases **********************
        [TestMethod]
        public void ComposeAndSendAnEmail()
        {
            Debug.WriteLine("Test Case : ComposeAndSendAnEmail");
            rcom.LaunchApplication();
            rcom.LoginToApplication();
            rcom.Compose();
            rcom.Send();
            rcom.LogoutFromApplication();
            rcom.CloseApplication();
        }
        [TestMethod]
        public void ReplyToAnEmail()
        {
            Debug.WriteLine("Test Case : ReplyToAnEmail");
            rcom.LaunchApplication();
            rcom.LoginToApplication();
            rcom.Open();
            rcom.Reply();
            rcom.LogoutFromApplication();
            rcom.CloseApplication();
        }
        [TestMethod]
        public void ForwardAnEmail()
        {
            Debug.WriteLine("Test Case : ForwardAnEmail");
            rcom.LaunchApplication();
            rcom.LoginToApplication();
            rcom.Open();
            rcom.Forward();
            rcom.LogoutFromApplication();
            rcom.CloseApplication();
        }
        [TestMethod]
        public void DeleteAnEmail()
        {
            Debug.WriteLine("Test Case : DeleteAnEmail");
            rcom.LaunchApplication();
            rcom.LoginToApplication();
            rcom.Open();
            rcom.Delete();
            rcom.LogoutFromApplication();
            rcom.CloseApplication();
        }
    }
}
