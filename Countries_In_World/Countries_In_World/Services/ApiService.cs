using Countries_In_World.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Countries_In_World.Services
{
    public class ApiService
    {
        public async static Task<List<Geoname>> GetCountries()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string key = "icebeam";
                string url = $"http://api.geonames.org/countryInfoJSON?username={key}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Root info = JsonConvert.DeserializeObject<Root>(json);
                    foreach(Geoname geoname in info.geonames)
                    {
                        geoname.FlagUrl = $"https://raw.githubusercontent.com/hjnilsson/country-flags/master/png250px/{geoname.countryCode.ToLower()}.png";
                    }
                    return info.geonames;
                }

            }
            return new List<Geoname>();

        }
    }
}
