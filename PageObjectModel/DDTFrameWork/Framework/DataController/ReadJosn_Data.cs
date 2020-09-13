using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    public class ReadJosn_Data
    {
        public string selector;
        public string data;
        public string JsonFilePath;
        public RootObject root;
        public ReadJosn_Data()
        {
           JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "AppData\\App_TestData.json";
        }
        public string GetSelector(string objectName)
        {
            return selector;
        }

        public RootObject GetTestData()
        {
            root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            return root;
        }
        public RootObject GetTestData(string env)
        {
            root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            return root;
        }
        public class RootObject
        {
            public Dev dev { get; set; }
            public QA qa { get; set; }
        }
        public class Dev
        {
            public string URL { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }
        }
        public class QA
        {
            public string URL { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }
        }
    }
}
