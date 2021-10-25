using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    [TestClass]
    public class GetAttachmentStatus : Utilities
    {
        string JsonFilePath;
        string dmsrefnum;
        RestClient client;
        RestRequest request;
        IRestResponse response;
        RootObject MetadataBefore;
        //RootObject MetadataAfter;
        List<List<RootObject>> MetaDataList;
        IList<string> dmsRefNumbers;
        //Userstory-TestCaseNumber-Title
        [TestMethod] //Test Case 1 : One DMS Number
        public void GetAttachmentStatusWithOneDmsNumber()
        {
            dmsRefNumbers = UploadDocumentToVyne(1);
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers);
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestCleanup]
        public void testCleanUp()
        {
            MetaDataList = null;
        }
        [TestMethod] //Test Case 2 : Two DMS Numbers
        public void GetAttachmentStatusWithTwoDmsNumbers()
        {
            dmsRefNumbers = UploadDocumentToVyne(2);
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers);
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 3 : Three DMS Numbers
        public void GetAttachmentStatusWithThreeDmsNumbers()
        {
            dmsRefNumbers = UploadDocumentToVyne(3);
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers);
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 4 : Four DMS Numbers
        public void GetAttachmentStatusWithFourDmsNumbers()
        {
            dmsRefNumbers = UploadDocumentToVyne(4);
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers);
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 5 : One DMS Numbers & One Valid FecilityID
        public void GetAttachmentStatusWithDmsNumberAndValidFecilityID()
        {
            dmsRefNumbers = UploadDocumentToVyne(1);
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"],dmsRefNumbers,"ABCD123");
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 6 : One DMS Numbers & One InValid FecilityID
        public void GetAttachmentStatusWithDmsNumberAndInValidFecilityID()
        {
            dmsRefNumbers = UploadDocumentToVyne(1);
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers, "ABCD123");
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here
        }
        [TestMethod] //Test Case 7 : One Invalid DMS Numbers & One InValid FecilityID
        public void GetAttachmentStatusWithInvalidDmsNumberAndInValidFecilityID()
        {
            dmsRefNumbers[0] = "890de2b5-ec3a-4b2b-9cab-4a63b1bf9111";
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers, "ABCD123");
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 8 : One Invalid DMS Numbers 
        public void GetAttachmentStatusWithInvalidDmsNumber()
        {
            dmsRefNumbers[0] = "890de2b5-ec3a-4b2b-9cab-4a63b1bf9111";
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], dmsRefNumbers);
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 9 :  One Valid FecilityID
        public void GetAttachmentStatusWithOneValidFecilityID()
        {
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], "abcd1234");
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here

        }
        [TestMethod] //Test Case 10 : Two FecilityIDs
        public void GetAttachmentStatusWithTwoFecilityIDs()
        {
            response = AttachmentStatus(ConfigurationManager.AppSettings["GetAttachmentStatus"], "abcd1234","xyzw123");
            MyResponses statusresponses = JsonConvert.DeserializeObject<MyResponses>(response.Content);
            //Do Assertion here
        }
        //*******************************************************************
        public IRestResponse AttachmentStatus(string endpoint,IList<string> dmsnumbers)
        {
            client = CreateRestClient(endpoint, dmsnumbers);
            response = RestRequest_POST(client);
            return response;
        }
        public IRestResponse AttachmentStatus(string endpoint, IList<string> dmsnumbers,string fecilityID)
        {
            client = CreateRestClient(endpoint, dmsnumbers);
            request = new RestRequest(Method.POST);
            request.AddParameter("fecilityID", fecilityID);
            response = client.Execute(request);
            return response;
        }
        public IRestResponse AttachmentStatus(string endpoint, IList<string> dmsnumbers, IList<string> fecilityIDs)
        {
            client = CreateRestClient(endpoint, dmsnumbers);
            request = new RestRequest(Method.GET);
            response = client.Execute(request);
            return response;
        }
        public IRestResponse AttachmentStatus(string endpoint,string fecilityID)
        {
            client = CreateRestClient(endpoint);
            request = new RestRequest(Method.POST);
            request.AddParameter("fecilityID", fecilityID);
            response = client.Execute(request);
            return response;
        }
        public IRestResponse AttachmentStatus(string endpoint, string fecilityID1, string fecilityID2)
        {
            client = CreateRestClient(endpoint);
            request = new RestRequest(Method.POST);
            request.AddParameter("fecilityID", fecilityID1);
            request.AddParameter("fecilityID", fecilityID2);
            response = client.Execute(request);
            return response;
        }

        public IList<string> UploadDocumentToVyne(int docCount)
        {
            for(int i=0;i<docCount;i++)
            {
                JsonFilePath = UpdatePDFFileName("NewSinglePage");
                MetadataBefore = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
                response = PostEASubmitterToVyne(ConfigurationManager.AppSettings["EASubmitterAPI"], JsonFilePath);
                dmsrefnum = AssertEASubmitterResponseAndGetDMSRefNum(response);
                response = DownloadAttachmentMetadata(ConfigurationManager.AppSettings["MetaDataAPI"], dmsrefnum);
                List<RootObject> MetadataAfter = JsonConvert.DeserializeObject<List<RootObject>>(response.Content);
                dmsRefNumbers[i] = dmsrefnum;
                //MetadataAfter.Add()
            }
            return dmsRefNumbers;

        }

        [TestMethod]
        public void UploadMultiAttachments2()
        {
            string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\") + "SeleniumPractice\\EASubmitter\\Data\\MultiAttachment.json";
            //responses = JsonConvert.DeserializeObject<Responses>(File.ReadAllText(JsonFilePath));
            MyResponses a = JsonConvert.DeserializeObject<MyResponses>(File.ReadAllText(JsonFilePath));
        }
        [TestMethod]
        public void ReadStatusResponse()
        {
            string JsonFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\") + "SeleniumPractice\\EASubmitter\\Data\\AttachmentStatus.json";
            //responses = JsonConvert.DeserializeObject<Responses>(File.ReadAllText(JsonFilePath));
            MyResponses a = JsonConvert.DeserializeObject<MyResponses>(File.ReadAllText(JsonFilePath));
        }

        //IList<string> msgs = new List<string>();
        ////[TestMethod]
        //public IList<string> ResMessages(string msg)
        //{
        //    //string msg = "{\"attachmentId\":48494,\"nte\":\"MEA#48494\",\"pwk\":\"MEA48494\"}";
        //    string[] nmsg = msg.Replace("\""," ").Replace("}", " ").Split(',');
        //    msgs.Add(nmsg[0].Split(':')[1].Trim()); msgs.Add(nmsg[1].Split(':')[1].Trim()); msgs.Add(nmsg[2].Split(':')[1].Trim());
        //    return msgs;
        //}
        public void ValidateGetAttachmentStatus(List<List<RootObject>> MetaDataList, MyResponses myResponses)
        {
            string nte = null;
            string pwk = null;
            for (int i = 0; i < MetaDataList.Count; i++)
            {
                Console.WriteLine("DMS Number :" + i + " - " + myResponses.Responses.ElementAt(i).dmsInternalReferenceNumber);
                var msgs = RespStatusMessages(MetaDataList.ElementAt(i).ElementAt(i).responseDetails.ResponseMessage);
                for(int j=0;j < MetaDataList.Count;j++)
                {
                    if (MetaDataList.ElementAt(i).ElementAt(0).attachment.dmsInternalReferenceNumber == myResponses.Responses.ElementAt(j).dmsInternalReferenceNumber)
                    {
                        nte = myResponses.Responses.ElementAt(j).nte;
                        pwk = myResponses.Responses.ElementAt(j).nte;
                    }
                }
                //Assert.AreEqual(msgs.attachmentId, myResponses.Responses.ElementAt(i).attachmentId);
                Assert.AreEqual(msgs.nte, nte);
                Assert.AreEqual(msgs.pwk, pwk);
            }
        }
        public RespMessages RespStatusMessages(string msg)
        {
            string[] nmsg = msg.Replace("\"", " ").Replace("}", " ").Split(',');
            return new RespMessages(nmsg[0].Split(':')[1].Trim(), nmsg[1].Split(':')[1].Trim(), nmsg[2].Split(':')[1].Trim());
        }

        public class RespMessages
        {
            public string attachmentId { get; set; }
            public string nte { get; set; }
            public string pwk { get; set; }
            public RespMessages(string attachmentId,string nte,string pwk)
            {
                this.attachmentId = attachmentId;
                this.nte = nte;
                this.pwk = pwk;
            }
        }

       
        // Responses responses;
        
        public AttachmentResponse attachmentResponse;
        public class MyResponses
        {
            public List<AttachmentResponse> Responses { get; set; }
        }
        public class AttachmentResponse
        {
            public string dmsInternalReferenceNumber { get; set; }
            public string neaNumber { get; set; }
            public string nte { get; set; }
            public string pwk { get; set; }
            public string attachmentId { get; set; }
        }
    }
}
