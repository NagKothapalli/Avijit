using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice
{
    [TestClass]
    public class Submitter
    {
        [TestMethod]
        public void PayloadReplace(){
            string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "SeleniumPractice\\Data\\EASubmitterPayLoad.json";
            JObject jObject = JsonConvert.DeserializeObject(File.ReadAllText(JsonFilePath)) as JObject;
            JToken jToken = jObject.SelectToken("attachment.dmsInternalReferenceNumber");
            Console.WriteLine(jToken.ToString());
            string newstring =  jToken.ToString().Replace(jToken.ToString().Split('-')[4], new Random().Next(999999999).ToString()+"abc");
            jToken.Replace(newstring);
            string updatedJsonString = jObject.ToString();
            File.WriteAllText(JsonFilePath, updatedJsonString);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            Console.WriteLine(root.attachment.dmsInternalReferenceNumber);
        }
        [TestMethod]
        public void ReadPayload()
        {
            string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "SeleniumPractice\\Data\\EASubmitterPayLoad.json";
            Console.WriteLine(JsonFilePath);
            RootObject root =  JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            //string json = File.ReadAllText("settings.json");
            //dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //jsonObj["Bots"][0]["Password"] = "new password";
            Console.WriteLine(root.attachment.dmsInternalReferenceNumber);
            root.attachment.dmsInternalReferenceNumber += "newvalue";
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(root, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFilePath, output);
            root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            Console.WriteLine(root.attachment.dmsInternalReferenceNumber);
            if((output) != null)
            {
                
            }
            Assert.AreNotEqual(null, output);
        }

        public class RootObject
        {
            public Attachment attachment { get; set; }
            public AttachmentDetails attachmentDetails { get; set; }
            public DocumentDetails documentDetails { get; set; }

        }
        public class Attachment
        {
            public string dmsInternalReferenceNumber { get; set; }
            
        }
        public class AttachmentDetails
        {
            public string stEndPoint { get; set; }
            public string tempAttachmentId { get; set; }
            public string metadatauploadStatus { get; set; }
            public string fileUploadStatus { get; set; }
        }
        public class DocumentDetails
        {
            public string vendorImageId { get; set; }
            public string fileName { get; set; }
            public string imageDate { get; set; }
            public string imageCode { get; set; }
            public string vendorTransactionId { get; set; }
        }
    }
}
