using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiniumDesktopAutomation
{
    [TestClass]
    public class WiniumAutomation
    {
        public WiniumDriver driver;
        [TestMethod]
        public void setupEnvironment() 
        {

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:/windows/system32/calc.exe");
            var driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            //var mainwindow = driver.FindElement(By.XPath("//[@ClassName='ApplicationFrameWindow' and @Name='Calculator']"));
            //var subwindow = mainwindow.FindElement(By.XPath("//[@ClassName='Windows.UI.Core.CoreWindow' and @Name='Calculator']"));
            var mainwindow = driver.FindElement(By.ClassName("ApplicationFrameWindow"));
           // var subwindow = mainwindow.FindElement(By.XPath("//window[@ClassName='Windows.UI.Core.CoreWindow' and @Name='Calculator']"));
            var NumberPad = mainwindow.FindElement(By.ClassName("LandmarkTarget")).FindElement(By.Id("NumberPad"));

            NumberPad.FindElement(By.Id("num8Button")).Click(); // 2
            //window.FindElement(By.Id("93")).Click(); // +
            //window.FindElement(By.Id("134")).Click(); // 4
            //window.FindElement(By.Id("97")).Click(); // ^
            //window.FindElement(By.Id("138")).Click(); // 8
            //window.FindElement(By.Id("121")).Click(); // =

            //driver.Close();
        }
    }
}


