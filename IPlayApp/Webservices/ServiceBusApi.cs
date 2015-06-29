using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IPlayApp.Models;
using Newtonsoft.Json;
using RestSharp.Portable;
using Xamarin.Forms;

namespace IPlayApp.Webservices
{
    public static class ServiceBusApi
    {
        public static async Task<Init> Fetch()
        {
            try
            {
                var client = new RestClient(Application.Current.Properties["Url"] as string);
                //var request = new RestRequest("test", HttpMethod.Get);
                var request = new RestRequest(String.Format(Application.Current.Properties["Segment"].ToString(), Application.Current.Properties["Variables"].ToString().Split(',')), HttpMethod.Get);


                var result = await client.Execute(request);
                if (result.IsSuccess)
                {
                    
                var resultString = Encoding.UTF8.GetString(result.RawBytes, 0, result.RawBytes.Length);
                var init = JsonConvert.DeserializeObject<Init>(resultString);
                return init;
                }
                return null;

            }
            catch (Exception e)
            {
               return null;
            }

        }
    }
}