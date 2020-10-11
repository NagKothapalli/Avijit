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
        //***********************Reusable Components *****************
        public IRestResponse DownloadAttachmentDocument(string endpoint,string dmsrefnum)
        {
            client = CreateRestClient(endpoint + dmsrefnum);
            response = RestRequest_GET(client);
            //Console.WriteLine(response.Content);
            return response;
        }
        public IRestResponse DownloadAttachmentMetadata(string endpoint, string dmsrefnum)
        {
            client = CreateRestClient(endpoint + dmsrefnum);
            response = RestRequest_GET(client);
            //Console.WriteLine(response.Content);
            return response;
        }
        public IRestResponse PostEASubmitterToVyne(string endpoint, string JsonFilePath)
        {
            client = CreateRestClient(endpoint);
            return RestRequest_POST(client, JsonFilePath);
        }
        public string AssertEASubmitterResponseAndGetDMSRefNum(IRestResponse response)
        {
            Assert.AreEqual("OK", response.StatusCode.ToString().Trim());
            return response.Content.ToString().Substring(1, response.Content.ToString().Length - 2);
        }
        public void WaitForSomeTimeInSeconds(int time)
        {
            Thread.Sleep(1000 * time);
        }
        public void AssertMetaDataFile(RootObject MetadataBefore, IRestResponse response)
        {
            IList<RootObject> MetadataAfter = JsonConvert.DeserializeObject<IList<RootObject>>(response.Content);
            Assert.AreNotEqual(null, MetadataAfter[0].attachment.dmsInternalReferenceNumber);
            Console.WriteLine("dmsInternalReferenceNumber=" + MetadataAfter[0].attachment.dmsInternalReferenceNumber);
            Assert.AreNotEqual(null, MetadataAfter[0].attachmentDetails.StEndPoint);
            Console.WriteLine("StEndpoint=" + MetadataAfter[0].attachmentDetails.StEndPoint);
            Assert.AreEqual("ca", MetadataAfter[0].attachmentDetails.SenderApplication);
            Assert.AreEqual("Success", MetadataAfter[0].attachmentDetails.MetadataUploadStatus);
            Assert.AreEqual("Success", MetadataAfter[0].attachmentDetails.FileUploadStatus);
            Assert.AreEqual(MetadataBefore.model.documentDetails.fileName, MetadataAfter[0].documentDetails.fileName);
            Assert.AreEqual("200", MetadataAfter[0].responseDetails.ResponseCode);
            Assert.AreNotEqual(null, MetadataAfter[0].responseDetails.ResponseMessage);
            Assert.AreEqual(MetadataBefore.model.attachment.payor.masterId, MetadataAfter[0].attachment.payor.masterId);
        }
        public void AssertPDFByteStream(string PdfUploaded, IRestResponse response)
        {
            string pdfbefore = PdfUploaded.Substring(1, PdfUploaded.Length - 1);
            string pdfafter = response.Content.ToString().Substring(2, response.Content.ToString().Length - 3);
            Assert.AreEqual(pdfbefore, pdfafter);
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

