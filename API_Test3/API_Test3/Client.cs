using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace API_Test3
{
    public class Client
    {


        public string EndPoint { get; set; }
        public Verb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }


        public Client()
        {
            EndPoint = "";
            Method = Verb.GET;
            ContentType = "application/JSON";
            PostData = "";
        }

        public Client(string endpoint, Verb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/JSON";
            PostData = postData;
        }

        public string Request()
        {
            return Request("");
        }

        public string Request(string parameters)
        {

            var request = (HttpWebRequest)WebRequest.Create(EndPoint+parameters);
            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            using (var response = (HttpWebRequest)request.GetResponse())
            {
                var responseValue = string.Empty;
                if (response.StatusCode !=HttpStatusCode.OK)
                {
                    var Message = string.Format("Fail: Received HTTP{0}", response.StatusCode);
                    throw new ApplicationException(Message);

                }


                using (var responseStream=response.GetResponseStream())
                {

                    if (responseStream != null)
                    {

                        using (var reader= new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                    }


                }
                return responseValue;


            }




        }




    }
}
