using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    [TestClass]
    public class WorkLinkReader

    {
        public WorkLinkSettings workLinkSettings;
        [TestMethod]
        public void ReadWorkLinkSettings()
        {
            string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\") + "SeleniumPractice\\EASubmitter\\Data\\WorkLink.json";
            //responses = JsonConvert.DeserializeObject<Responses>(File.ReadAllText(JsonFilePath));
            WorkLinkSettings a = JsonConvert.DeserializeObject<WorkLinkSettings>(File.ReadAllText(JsonFilePath));
        }
        public class WorkLinkSettings
        {
            public CMSSettings cMSSettings;
            public List<Device> Devices { get; set; }
        }
        public class Device
        {
            public string Url { get; set; }
            public string UserName { get; set; }
            public string PassWord { get; set; }
            public string BadPassWord { get; set; }
            public string DeviceType { get; set; }
            public string Environment { get; set; }
            public string TestingType { get; set; }
            public string Browser { get; set; }
            public string APKFilePath { get; set; }
        }
        public class CMSSettings
        {
            public string ExecutionType { get; set; }
            public string Browser { get; set; }
            public string OS { get; set; }
            public string Environment { get; set; }
        }
    }
    
   
}
