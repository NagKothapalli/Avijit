using DDTFrameWork.App.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.App.TestScenarios
{
    [TestClass]
    public class TestCases
    {
        public Login login;
        public TestCases()
        {
            login = new Login();
        }
        [TestMethod]
        public void GmailLogin()
        {
            login.LaunchApplication();
            login.LoginToApplication();
            login.LogoutFromApplication();
        }
    }
}
