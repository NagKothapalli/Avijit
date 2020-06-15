
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.InheritanceByExtends
{
    [TestClass]
    public class Gmail
    {
        ExtentReports extent;
        //Signature :  Class , Variable , Function 
        // Class Signature : Modifier  class  Name{ body : members -> variable , function }
        // Variable Signature : Modifier[opt]  DataType   Name = value;
        //Variables : Local and Instance
        public string StdName = "Ram";
        private int StdNum = 22;
        protected double StdMarks = 22.67;
        Boolean StdResult = true;
        Char StdGrade = 'A';
        // Function : Signature : Modifier[opt]  ReturnType  Name(arguments...[opt]){Body}
        private int sum; // instance variable
        //:D:\WorkSpace\CsharpGit\PageObjectModel\Selenium
        [TestMethod]
        public void Addition()
        {
           extent = new ExtentReports(@"D:\WorkSpace\CsharpGit\PageObjectModel\Selenium\Reports\TestReports.html");
           ExtentTest myTest = extent.StartTest("Smoke");
           sum =  22 + 44;  // local variable - visible within the function
           Debug.WriteLine("Sum of Two Numbers :" + sum);
           Debug.WriteLine("Base Directory :" + AppDomain.CurrentDomain.BaseDirectory);
           Debug.WriteLine("Current Directory :" + Environment.CurrentDirectory);
           //myTest.AppendChild("Compose");
           myTest.Log(LogStatus.Pass, "Launch Application Successfull");
           myTest.Log(LogStatus.Pass, "Login Application Successfull");
           myTest.Log(LogStatus.Pass, "Logout Application Successfull");
           myTest.Log(LogStatus.Pass, "Close Application Successfull");
           extent.EndTest(myTest);
           extent.Flush();
           extent.Close();
        }
        //A Test Method should not be static , not have inputs , should be always public
        [TestMethod]
        public void Additions()
        {
            Addition(55, 88);
        }
        public void Addition(int a,int b)  // Method overloading - polymorphism
        {
            sum = a + b;
            Debug.WriteLine("Sum of Two Numbers :" + sum);
        }
        public void Addition(int a, string b)  // Method overloading - polymorphism
        {
            string sum = a + b;
            Debug.WriteLine("Sum of Two Numbers :" + sum);
        }
        public int Addition(int a, int b,int c)  // Method overloading - polymorphism
        {
            sum = a + b + c ;
            //Debug.WriteLine("Sum of Two Numbers :" + sum);
            sum = sum + 66;
            return sum;
        }



    }
}
