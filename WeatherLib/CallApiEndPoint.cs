using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    public class CallApiEndPoint
    {
        public static async Task<string> LoadDataFromGivenUrl(string url)
        {
            //string url = $"http://dataservice.accuweather.com/locations/v1/topcities/150?apikey=KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
