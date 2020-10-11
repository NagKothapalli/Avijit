using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    public class Read_ConfigData
    {
        public string JsonFilePath;
        public RootObject root;
        public Read_ConfigData()
        {
            JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "AppData\\App_TestConfig.json";
            root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        }
        //public RootObject GetTestConfig()
        //{
        //    return root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        //}
       
        public class RootObject
        {
            public AppRunSettings appRunSttings { get; set; }
            public WebRunSettings webRunSttings { get; set; }
        }
        public class AppRunSettings
        {
            public string DeviceType { get; set; }
            public string IPAddress { get; set; }
            public string metadatauploadStatus { get; set; }
            public string fileUploadStatus { get; set; }
        }
        public class WebRunSettings
        {
            public string ExecutionType { get; set; }
            public string Browser { get; set; }
            public string OS { get; set; }
            public string Environment { get; set; }
        }
    }
}
