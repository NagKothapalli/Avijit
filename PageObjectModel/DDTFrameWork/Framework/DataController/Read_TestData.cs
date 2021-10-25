using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    public class Read_TestData
    {
        public string selector;
        //public string data;
        public string JsonFilePath;
        public Data data;
        public Read_TestData(string env)
        {
           JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "AppData\\App_"+env+"Data.json";
           data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(JsonFilePath));
        }        
        //public RootObject GetTestData()
        //{
        //    root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        //    return root;
        //}
        //public RootObject GetTestData(string env)
        //{
        //    root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        //    return root;
        //}
        //public class RootObject
        //{
        //    public Data data { get; set; }            
        //}
        public class Data
        {
            public string URL { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }
        }       
    }
}
