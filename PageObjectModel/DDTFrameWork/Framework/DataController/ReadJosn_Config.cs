using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    public class ReadJosn_Config
    {
        public string selector;
        public string data;
        public string GetSelector(string objectName)
        {
            return selector;
        }

        public string GetTestData(string page,string key)
        {
            return data;
        }

        public void ReadPayload()
        {
            string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "AppData\\App_TestData.json";
            Console.WriteLine(JsonFilePath);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        }
        public class RootObject
        {
            public Dev dev { get; set; }
            //public QA qa { get; set; }
        }
        public class Dev
        {
            public string stEndPoint { get; set; }
            public string tempAttachmentId { get; set; }
            public string metadatauploadStatus { get; set; }
            public string fileUploadStatus { get; set; }
        }
    }
}
