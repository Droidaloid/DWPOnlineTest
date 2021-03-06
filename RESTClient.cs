using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using DWPOnlineTest.Models;

namespace DWPOnlineTest
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        
        public RestClient(string endPoint, httpVerb httpMethod)
        {
            this.endPoint = endPoint;
            this.httpMethod = httpMethod;
        }

        public RestClient()
        {
            this.endPoint = string.Empty;
            this.httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                }
                

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }

        public IEnumerable<User> makeDeserialisedRequestMultiple()
        {
            string response = makeRequest();

            return JsonConvert.DeserializeObject<IEnumerable<User>>(response);
        }

        public User makeDeserialisedRequestSingle()
        {
            string response = makeRequest();

            return JsonConvert.DeserializeObject<User>(response);
        }

    }
}