using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SeleniumPractice.EASubmitter
{
    public class Utilities
    {
        string path;
        RestClient client;
        IRestResponse response;
        public string UpdateDMSInternalReferenceNumber(string path)
        {
            return path;
        }
        public RestClient CreateRestClient(string endpoint)
        {
            return client;
        }
        public IRestResponse RestRequest_POST(RestClient client,string path)
        {
            return response;
        }
        public IRestResponse RestRequest_GET(RestClient client)
        {
            return response;
        }
        public string UpdatePDFFileName(string path)
        {
            return path;
        }
    }
}
