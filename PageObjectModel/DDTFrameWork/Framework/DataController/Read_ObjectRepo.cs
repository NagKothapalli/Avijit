using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDTFrameWork.Framework
{
    public class Read_ObjectRepo
    {
        public string selector;
        public string data;
        public RootObject root;
        public string JsonFilePath;
        public Read_ObjectRepo()
        {
            JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", @"\") + "AppData\\App_ObjectRepo.json";
            root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        }
        //public RootObject GetSelector()
        //{
        //    return root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        //}
        //public RootObject GetSelector(string objectName)
        //{
        //    root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
        //    return root;
        //}
        public class RootObject
        {
            public LoginPage loginPage { get; set; }
        }
        public class LoginPage
        {
            public string UserName { get; set; }
            public string NextButton { get; set; }
            public string PassWord { get; set; }
            public string LogoutButton { get; set; }
        }
    }
}
