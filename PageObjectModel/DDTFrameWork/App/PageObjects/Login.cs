﻿using DDTFrameWork.App.TestingTypes;
using DDTFrameWork.Framework;
using DDTFrameWork.Framework.ObjectManager;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        public Read jsonData;
        public ReadJosn_Repo.LoginPage loginRepo;
        public Dev devData;
        IWebDriver driver ;
        public Login()
        {
            devData = new ReadJosn_Data().GetTestData().dev;
            loginRepo = new ReadJosn_Repo().GetSelector().loginPage;
            PageFactory.InitElements(driver, this);
        }
        //************************ Object Repo *********************
        [FindsBy(How = How.XPath, Using = "//input[@id='username']")] public IWebElement UserName;
        [FindsBy(How = How.XPath, Using = "//input[@id='password']")] public IWebElement PassWord;
        //**********************************************************
        public void LaunchApplication()
        {
            WebSuites.webDriver.Navigate().GoToUrl(devData.URL);
        }
        public void LoginToApplication()
        {
            //UserName.SendKeys("abcd");
            //PassWord.SendKeys("xyz");
            TextBoxControl(loginRepo.UserName).Set(devData.UserName);
            ButtonControl(loginRepo.NextButton).Click();
            Thread.Sleep(2000);
            TextBoxControl(loginRepo.PassWord).Set(devData.PassWord);
            ButtonControl(loginRepo.NextButton).Click();
        }

        public void LaunchApplication(string url)
        {
            WebSuites.webDriver.Navigate().GoToUrl(devData.URL);
        }
        public void LoginToApplication(string un,string pw)
        {
           
            TextBoxControl(loginRepo.UserName).Set(un);
            ButtonControl(loginRepo.NextButton).Click();
            Thread.Sleep(2000);
            TextBoxControl(loginRepo.PassWord).Set(pw);
            ButtonControl(loginRepo.NextButton).Click();
        }

        public void VerifyUserLogin()
        {
            Console.WriteLine("User Logged in Successfully");
        }
        public void LogoutFromApplication()
        {
            //ButtonControl(loginRepo.LogoutButton).Click();
        }
    }
}
