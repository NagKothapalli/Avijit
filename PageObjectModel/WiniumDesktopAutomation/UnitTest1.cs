using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using System.Threading;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Remote;

namespace WiniumDesktopAutomation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AutomateCalculator()
        {
            DesktopOptions option = new DesktopOptions {ApplicationPath = "C:\\Windows\\System32\\calc.exe" };
            WiniumDriverService service = WiniumDriverService.CreateDesktopService(@"D:\WorkSpace\WinAppDriver");
            WiniumDriver driver = new WiniumDriver(service, option);
            Thread.Sleep(10000);
            IWebElement mainwindow = driver.FindElement(By.ClassName("ApplicationFrameWindow"));
            IWebElement NumberPad = mainwindow.FindElement(By.ClassName("LandmarkTarget")).FindElement(By.Id("NumberPad"));
            IWebElement StandardOperators = mainwindow.FindElement(By.ClassName("LandmarkTarget")).FindElement(By.Id("StandardOperators"));
            NumberPad.FindElement(By.Id("num8Button")).Click(); 
            NumberPad.FindElement(By.Id("num7Button")).Click();
            NumberPad.FindElement(By.Id("num9Button")).Click(); 
            StandardOperators.FindElement(By.Id("plusButton")).Click();
            NumberPad.FindElement(By.Id("num9Button")).Click();
            NumberPad.FindElement(By.Id("num7Button")).Click(); //97
            StandardOperators.FindElement(By.Id("equalButton")).Click();
            driver.Quit();
        }
        [TestMethod]
        public void AutomateNotePad()
        {
            DesktopOptions option = new DesktopOptions { ApplicationPath = "C:\\Windows\\System32\\notepad.exe" };
            WiniumDriverService service = WiniumDriverService.CreateDesktopService(@"D:\WorkSpace\WinAppDriver"); //We can have both application and winium driver inside the project
            WiniumDriver driver = new WiniumDriver(service, option);
            Thread.Sleep(10000);
            driver.FindElement(By.ClassName("Notepad")).FindElement(By.ClassName("Edit")).SendKeys("Welcome to Winium Automation");
            driver.Quit();
        }
       

       
    }
}
