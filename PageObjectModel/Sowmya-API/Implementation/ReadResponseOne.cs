using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sowmya_API.Implementation
{
    [TestClass]
    public class ReadResponseOne
    {
        public string selector;
        public string JsonFilePath;
        public Root data;
        public ReadResponseOne()
        {
            String BaseDir = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("My Base Directory :" + BaseDir);
            JsonFilePath = BaseDir.Replace(@"\bin\Debug", @"\") + "PayLoads\\Response.json";
            data = JsonConvert.DeserializeObject<Root>(File.ReadAllText(JsonFilePath));
        }
        [TestMethod]
        public void ReadJsonContent()
        {
            String a = data.description;
            String T_id =  data.responses[0].trackingId;
            Console.WriteLine("My Tracking ID :" + T_id);
            Assert.AreEqual("9mmzzd0e-d6ec-4220-b6ec-d341277d58c1", T_id);
        }

    }
    public class Respons
    {
        public string trackingId { get; set; }
        public string createdDateUtc { get; set; }
        public string contentUrl { get; set; }
        public List<string> targetAddresses { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string accountNumber { get; set; }
        public string templateId { get; set; }
        public string messageType { get; set; }
        public string appId { get; set; }
    }
    public class Root
    {
        public List<Respons> responses { get; set; }
        public string description { get; set; }
        public object errors { get; set; }
    }
}
