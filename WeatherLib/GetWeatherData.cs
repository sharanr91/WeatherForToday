using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    public class GetWeatherData
    {

        public static async Task<string> LoadWeatherData(int locationKey)
        {
            string url = $"http://dataservice.accuweather.com/currentconditions/v1/{ locationKey }?apikey=KAsv18xGJd2pRClNCSKaDLR4NOx9HCPM";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                    


                    //WeatherInfoModel weatherInfo = await response.Content.ReadAsAsync<WeatherInfoModel>();

                    //return weatherInfo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
