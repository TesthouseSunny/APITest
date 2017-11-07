using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Verb
{
GET,
POST,
PUT,
DELETE
}


namespace API_Test3
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new Client();
            client.EndPoint = @"https://restcountries.eu";
            client.Method = Verb.GET;

            var pdata = client.PostData;
            var response = client.Request("/rest/v1/currency/eur");

        }
    }
}
