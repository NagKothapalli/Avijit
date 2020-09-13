using DDTFrameWork.App.TestingTypes;
using DDTFrameWork.Framework;
using DDTFrameWork.Framework.ObjectManager;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDTFrameWork.App.PageObjects
{
    public class Login : ObjManager
    {
        public ReadJosn_Data jsonData;
        public ReadJosn_Repo.LoginPage loginRepo;
        public Dev devData;
        IWebDriver driver ;
        public Login()
        {
            devData = new ReadJosn_Data().GetTestData().dev;
            loginRepo = new ReadJosn_Repo().GetSelector().loginPage;
        }
        public void LaunchApplication()
        {
            WebSuites.webDriver.Navigate().GoToUrl(devData.URL);
        }
        public void LoginToApplication()
        {
            TextBoxControl(loginRepo.UserName).Set(devData.UserName);
            ButtonControl(loginRepo.NextButton).Click();
            Thread.Sleep(2000);
            TextBoxControl(loginRepo.PassWord).Set(devData.PassWord);
            ButtonControl(loginRepo.NextButton).Click();
        }
        public void LogoutFromApplication()
        {
            //ButtonControl(loginRepo.LogoutButton).Click();
        }
    }
}
