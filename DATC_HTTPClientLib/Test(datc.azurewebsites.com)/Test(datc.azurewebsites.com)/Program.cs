using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Test_datc.azurewebsites.com_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(GetCollection);
            //t.Start();



            GetCollection();
            InsertValueToKey(222);
            GetCollection();
            Console.ReadLine();


        }


        static async void GetCollection()
        {
            HttpClient hcReq = new HttpClient
            {
                BaseAddress = new Uri("http://datc-lab.azurewebsites.net")
            };

            HttpResponseMessage response = hcReq.GetAsync("/api/values").Result;
            HttpContent content = response.Content;

            // ... Read the string.
            var result = content.ReadAsStringAsync();

            // ... Display the result.
            if (result != null)
            {
                Console.WriteLine(result.Result);
            }
            else
            {
                Console.Beep();
            }

        }

        static async void InsertValueToKey(int key)
        {
            #region commented
            //HttpClient hcReq = new HttpClient
            //{
            //    BaseAddress = new Uri("http://datc-lab.azurewebsites.net")
            //};

            
            //string x = "ceva";
            //Stream streamCont = x;
            //HttpContent cont = new StreamContent(streamCont);
            //HttpResponseMessage response = hcReq.PostAsync("api/Values?key="+key,);
            //HttpContent content = response.Content;

            //// ... Read the string.
            //var result = content.ReadAsStringAsync();

            //// ... Display the result.
            //if (result != null)
            //{
            //    Console.WriteLine(result.Result);
            //}
            //else
            //{
            //    Console.Beep();
            //}
            #endregion


            using (var client = new HttpClient())
            {
                HttpHeaders head;
               
                client.BaseAddress = new Uri("http://datc-lab.azurewebsites.net");
                

                //var content = new FormUrlEncodedContent(new[] 
                //            {
                //                new KeyValuePair<string, string>("", "alabala")
                //            });

                var content = new StringContent("\"orice\"");
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/json");
                var result = client.PostAsync("api/Values?key=" + key, content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
            }

        }
    }
}
