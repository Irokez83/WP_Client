using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WishProjectClient
{
    class Program
    {
        class Client
        {
            //main method calls RunAsync()
            static void Main()
            {
                Task result = RunAsync();
                result.Wait();
            }
            static async Task RunAsync()
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        //set the base address and set for JSON
                        client.BaseAddress = new Uri("http://WishProject.AzureWebsites.net/");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        //get all christmas gifts by user
                        HttpResponseMessage response = await client.GetAsync("Christmas");
                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Here are all the Christmas gifts: ");
                            var gifts = await response.Content.ReadAsAsync<IEnumerable<ChristmasUser>>();
                            foreach (var g in gifts)
                            {
                                Console.WriteLine(g);
                            }
                            Console.ReadLine();
                        }
                        else
                            Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }
    }
}
