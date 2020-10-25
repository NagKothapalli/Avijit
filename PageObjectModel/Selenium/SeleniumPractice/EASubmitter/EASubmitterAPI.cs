using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    public class EASubmitterAPI : Utilities
    {
        string JsonFilePath;
        string dmsrefnum;
        RestClient client;
        RestRequest request;
        IRestResponse response;
        RootObject MetadataBefore;
        //Userstory-TestCaseNumber-Title
        [TestMethod]//US69682- End to End Automation
        public void UploadSinglePagePDFtoVyne()
        {
            JsonFilePath = UpdatePDFFileName("NewSinglePage");
            MetadataBefore = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            response = PostEASubmitterToVyne(ConfigurationManager.AppSettings["EASubmitterAPI"], JsonFilePath);
            dmsrefnum =  AssertEASubmitterResponseAndGetDMSRefNum(response);
            Console.WriteLine("DmsInternalReferenceNumber=" + response.Content); //Delete it
            WaitForSomeTimeInSeconds(40);
            response = DownloadAttachmentMetadata(ConfigurationManager.AppSettings["MetaDataAPI"] , dmsrefnum);
            Console.WriteLine("MetadataFileFromCosmosDB=" + response.Content); //Delete it
            AssertMetaDataFile(MetadataBefore,response);
            response = DownloadAttachmentDocument(ConfigurationManager.AppSettings["DocumentAPI"] , dmsrefnum);
            Console.WriteLine("DocumentFromAzureStorage=" + response.Content); //Delete it
            AssertPDFByteStream(MetadataBefore.pdfattachement.ToString(),response);
        }
        [TestMethod]//US69682- End to End Automation
        public void UploadSinglePagePDFtoVyne_VolumeTest()
        {
            for(int i=1;i<=10;i++)
            {
                JsonFilePath = UpdatePDFFileName("NewSinglePage");
                MetadataBefore = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
                response = PostEASubmitterToVyne(ConfigurationManager.AppSettings["EASubmitterAPI"], JsonFilePath);
                dmsrefnum = AssertEASubmitterResponseAndGetDMSRefNum(response);
                Console.WriteLine("DmsInternalReferenceNumber=" + response.Content); //Delete it
                WaitForSomeTimeInSeconds(40);
                response = DownloadAttachmentMetadata(ConfigurationManager.AppSettings["MetaDataAPI"], dmsrefnum);
                Console.WriteLine("MetadataFileFromCosmosDB=" + response.Content); //Delete it
                AssertMetaDataFile(MetadataBefore, response);
                response = DownloadAttachmentDocument(ConfigurationManager.AppSettings["DocumentAPI"], dmsrefnum);
                Console.WriteLine("DocumentFromAzureStorage=" + response.Content); //Delete it
                AssertPDFByteStream(MetadataBefore.pdfattachement.ToString(), response);
                WaitForSomeTimeInSeconds(10);
            }
            
        }
        public void UploadMultiPagePDFtoVyne()
        {
            JsonFilePath = UpdatePDFFileName("NewMultiPage");
            MetadataBefore = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(JsonFilePath));
            response = PostEASubmitterToVyne(ConfigurationManager.AppSettings["EASubmitterAPI"], JsonFilePath);
            string dmsrefnum = AssertEASubmitterResponseAndGetDMSRefNum(response);
            Console.WriteLine("DmsInternalReferenceNumber=" + response.Content); //Delete it
            WaitForSomeTimeInSeconds(40);
            response = DownloadAttachmentMetadata(ConfigurationManager.AppSettings["MetaDataAPI"] , dmsrefnum);
            Console.WriteLine("MetadataFileFromCosmosDB=" + response.Content); //Delete it
            AssertMetaDataFile(MetadataBefore, response);
            response = DownloadAttachmentDocument(ConfigurationManager.AppSettings["DocumentAPI"] , dmsrefnum);
            Console.WriteLine("DocumentFromAzureStorage=" + response.Content); //Delete it
            AssertPDFByteStream(MetadataBefore.pdfattachement.ToString(), response);
        }
        [TestMethod]//US69497
        public void GetAttachmentDocument()
        {
            response = DownloadAttachmentDocument(ConfigurationManager.AppSettings["DocumentAPI"] , "9ee749cd-2c9c-4f1a-8758-3f0277e409d2");
        }
        [TestMethod]
        public void GetAttachmentMetadata()
        {
            response = DownloadAttachmentMetadata(ConfigurationManager.AppSettings["MetaDataAPI"] , "9ee749cd-2c9c-4f1a-8758-3f0277e409d2");
        }
        
        //***************Old TestCases *******************
        //Userstory-testcasenum-Title
        [TestMethod]
        public void UploadPDFWithSinglePage()
        {
            JsonFilePath = UpdateDMSInternalReferenceNumber("SinglePage");
            client = CreateRestClient("https://app-easubmitter-api-dev-eastus.azurewebsites.net/api/Attachment");
            response = RestRequest_POST(client, JsonFilePath);
            Console.WriteLine(response.Content);
            Assert.AreEqual("OK", response.StatusCode.ToString().Trim());
        }
        [TestMethod]
        public void UploadPDFWitMultiPage()
        {
            JsonFilePath = UpdateDMSInternalReferenceNumber("MultiPage");
            client = CreateRestClient("https://app-easubmitter-api-dev-eastus.azurewebsites.net/api/Attachment");
            response = RestRequest_POST(client, JsonFilePath);
            Console.WriteLine(response.Content);
            Assert.AreEqual("OK", response.StatusCode.ToString().Trim());
        }
    }
    //******************Payload and Rest Response Classes **************************
    public class Model
    {
        public Attachment attachment { get; set; }
        public DocumentDetails documentDetails { get; set; }

    }
    public class RootObject
    {
        public Attachment attachment { get; set; }
        public AttachmentDetails attachmentDetails { get; set; }
        public DocumentDetails documentDetails { get; set; }
        public ResponseDetails responseDetails { get; set; }
        public Model model { get; set; }
        public string pdfattachement { get; set; }
    }
    public class Attachment
    {
        public string dmsInternalReferenceNumber { get; set; }
        public Payor payor { get; set; }

    }
    public class Payor
    {
        public int masterId { get; set; }

    }
    public class AttachmentDetails
    {
        public string StEndPoint { get; set; }
        public string SenderApplication { get; set; }
        public string MetadataUploadStatus { get; set; }
        public string FileUploadStatus { get; set; }
    }
    public class DocumentDetails
    {
        public string fileName { get; set; }
    }
    public class ResponseDetails
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}

