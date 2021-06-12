using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CSharp_Recap.Assignment_2
{
    public class Assignment_2
    {
        public static void main()
        {
            List<string> content = new List<string>();
            WebRequest[] request = new WebRequest[2];
            request[0] =  HttpWebRequest.Create("https://reqres.in/api/products/");
            request[1] = HttpWebRequest.Create("https://reqres.in/api/users?page=2");

            foreach(var req in request)
            {
                WebResponse response = req.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  
                content.Add(urlText);
                //Console.Write(urlText.ToString());
                Console.WriteLine();

            }

            foreach (var aPart in content)
            {
                Console.WriteLine(aPart);
            }

        }
        
    }
}
