using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp
{
    [TestClass]
    public class RestAutomation
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new RestClient("https://demoqa.com/Account/v1/GenerateToken");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/json", "D:/WorkSpace/Csharp/RestData/Data.json", ParameterType.RequestBody);
            //request.AddJsonBody(locationJSON);
            var response = client.Execute(request);
            Console.WriteLine("My Response :" + response.Content);
        }
    }
}
