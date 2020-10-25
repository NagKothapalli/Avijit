using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    public class Utilities
    {
        string path;
        RestClient client;
        IRestResponse response;
        IRestRequest request;
        public string UpdateDMSInternalReferenceNumber(string path)
        {
            return path;
        }
        public RestClient CreateRestClient(string endpoint)
        {
            client = new RestClient(endpoint);
            return client;
        }
       
        string newstring;
        public RestClient CreateRestClient(string endpoint, IList<string> parameters)
        {
            for(int i=0;i<parameters.Count;i++ )
            {
                dms = dms + "dmsInternalRefNum=" + parameters[i]+"&";
            }
            endpoint = endpoint + dms;
            client = new RestClient(endpoint);
            return client;
        }
        string dms;
        string fecility = "fecilityID=";
        IList<string> fecilityIDs = new List<string>();
        //fecilityIDs.Add("abcd123");
        //fecilityIDs.Add("abcd123");

        public RestClient CreateRestClient(string endpoint, IList<string> parameters, string[] fecilityIDs)
        {
            if (parameters.Count > 0)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    parameters[i] = parameters[i] + ",";
                    dms = dms + parameters[i];
                }
                dms = dms.Substring(0, dms.Length - 1);
            }
            if(fecilityIDs.Length > 0)
            {
                for (int i = 0; i < fecilityIDs.Length; i++)
                {
                    fecilityIDs[i] = fecilityIDs[i] + ",";
                    fecility = fecility + fecilityIDs[i];
                }
            }            
            endpoint = endpoint + dms +"&"+ fecility;
            client = new RestClient(endpoint);
            return client;
        }
        public IRestResponse RestRequest_POST(RestClient client)
        {
            request = new RestRequest(Method.POST);            
            return client.Execute(request);
        }
        public IRestResponse RestRequest_POST(RestClient client, string JsonFilePath)
        {
            request = new RestRequest(Method.POST);
            request.AddJsonBody(JsonFilePath);
            return client.Execute(request); ;
        }
        public IRestResponse RestRequest_POST(RestClient client, IList<string> parameters)
        {
            request = new RestRequest(Method.POST);
            //request.AddParameter("dmsInternalRefNum", parameters);
            for(int i=0;i<parameters.Count;i++)
            {
                request.AddParameter("dmsInternalRefNum", parameters[i]);
            }
            return client.Execute(request);
        }
        public IRestResponse RestRequest_GET(RestClient client)
        {
            request = new RestRequest(Method.GET);
            return client.Execute(request);
        }
        public string UpdatePDFFileName(string path)
        {
            return path;
        }
        //***********************Reusable Components *****************
        public IRestResponse DownloadAttachmentDocument(string endpoint, string dmsrefnum)
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
        public IRestResponse GetAttachmentStatus(string endpoint, IList<string> dmsnumber)
        {
            endpoint = endpoint + "dmsInternalRefNum=" + dmsnumber;
            client = CreateRestClient(endpoint);
            return RestRequest_POST(client);
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
    }
}
