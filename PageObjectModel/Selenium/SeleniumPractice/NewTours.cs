using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice
{
    [TestClass]
    public class NewTours
    {
        IWebDriver driver;
        //IWebDriver driver = new ChromeDriver();
        public void LaunchApplication()
        {
            Debug.WriteLine("RC : Launch Application");
            driver.Navigate().GoToUrl("https://gmail.com");
        }
        //id,name,class,cssSelector,linkText,partialLinkText,tagname,xpath
        [TestMethod]
        public void NewUserRegistration() //Test Case
        {
            //SelectElement
            LaunchApplication();
            Random random = new Random();
            int num = random.Next(9999);
            string username = "JohnDavid" + num;
            driver.FindElement(By.LinkText("REGISTER")).Click();
            driver.FindElement(By.Name("firstName")).SendKeys("John");
            driver.FindElement(By.Name("lastName")).SendKeys("David");
            driver.FindElement(By.Name("phone")).SendKeys("2342345467");
            driver.FindElement(By.Id("userName")).SendKeys("John@david.com");
            driver.FindElement(By.XPath("//input[@name='address1']")).SendKeys("Main Street 123");
            driver.FindElement(By.XPath("//input[@name='address2']")).SendKeys("Star County");
            driver.FindElement(By.XPath("//input[@name='city']")).SendKeys("NewYork");
            driver.FindElement(By.XPath("//input[@name='state']")).SendKeys("NY");
            driver.FindElement(By.XPath("//input[@name='postalCode']")).SendKeys("10020");
            Debug.WriteLine("New UserName :" + username);
            driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(username); //UserName
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("John@1234");
            driver.FindElement(By.XPath("//input[@name='confirmPassword']")).SendKeys("John@1234");
            driver.FindElement(By.XPath("//input[@name='register']")).Click();
            //IWebElement SuccessObj = driver.FindElement(By.XPath("//b[contains(text(),' Note: Your user name is')]"));
            IWebElement SuccessObj = driver.FindElement(By.XPath("//b[(text()=' Note: Your user name is "+username+".')]"));
            if (SuccessObj.Displayed)
            //if(SuccessObj.Text.Contains(username))
            {
                Debug.WriteLine("New User Registration is Successfull");
            }
            else
            {
                Debug.WriteLine("New User Registration is Failed");
            }
        }
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("https://demoqa.com/Account/v1/GenerateToken");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            //FileStream fs = File.OpenRead("D://WorkSpace//Csharp//RestData//Data.JSON");
            string jsonData = @"{
                                  ""userName"": ""nag1"",
                                  ""password"": ""Nag@1235""
                                }";
            //request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(fs), ParameterType.RequestBody);
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            //request.AddJsonBody(locationJSON);

            var response = client.Execute(request);
            Console.WriteLine("My Response :" + response.Content);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var client = new RestClient("https://demoqa.com/");
            var request = new RestRequest("Account/v1/GenerateToken", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            //client.Authenticator = new HttpBasicAuthenticator("username","password");
            //FileStream fs = File.OpenRead("D://WorkSpace//Csharp//RestData//Data.JSON");
            //string jsonData = @"{
            //                      ""userName"": ""nag1"",
            //                      ""password"": ""Nag@1235""
            //                    }";
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Base Directory :" + baseDir);

           request.AddParameter("application/json; charset=utf-8", JsonConvert.DeserializeObject(File.ReadAllText("D://WorkSpace//Csharp//RestData//Data.json")), ParameterType.RequestBody);
            //request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            //request.AddJsonBody(locationJSON);

            var response = client.Execute(request);
            Console.WriteLine("My Response :" + response.Content  + "Status code :" +  response.StatusDescription);
            TokenResponse userObj = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
            //Assert.AreEqual()
        }
        class TokenResponse
        {
            public string token { get; set; }
            public string expires { get; set; }
            public string status { get; set; }
            public string result { get; set; }
        }
        [TestMethod]
        public void TestMethod3()
        {
            var client = new RestClient("https://demoqa.com/BookStore/v1/Books");
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            //FileStream fs = File.OpenRead("D://WorkSpace//Csharp//RestData//Data.JSON");
            //string jsonData = @"{
            //                      ""userName"": ""nag1"",
            //                      ""password"": ""Nag@1235""
            //                    }";
            //request.AddParameter("application/json; charset=utf-8", JsonConvert.DeserializeObject(File.ReadAllText("D://WorkSpace//Csharp//RestData//Data.json")), ParameterType.RequestBody);
            //request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            //request.AddJsonBody(locationJSON);
            var response = client.Execute(request);
            Console.WriteLine("My Response :" + response.Content + "Status code :" + response.StatusCode + response.ResponseStatus);
            BooksList allbooks = JsonConvert.DeserializeObject<BooksList>(response.Content);
        }
        class BooksList
        {
            public IList<Book> books;
        }
        class Book
        {
            public string isbn { get; set; }
            public string title { get; set; }
        }
    }
}
