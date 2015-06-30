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

        //Should be dynamic.
        public static async Task Send()
        {
            try
            {
                var client = new RestClient("http://92.222.119.2:8086/");
                string[] vars = Application.Current.Properties["Variables"].ToString().Split(',');
                var request = new RestRequest("api/values?device=" + vars[0] + "&eventname=penalty&priority=1", HttpMethod.Get);
                var result = await client.Execute(request);
            }
            catch (Exception e)
            {

            }
        }
    }
}