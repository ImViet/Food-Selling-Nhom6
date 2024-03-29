﻿using Newtonsoft.Json;

namespace FoodSelling.CustomerSite.Extensions
{
    public static class HttpClientApi
    {
        public static ResponseType GetDataFromAPIAsync<ResponseType>(this HttpClient httpClient, string url)
        {
            var response = httpClient.GetAsync(url).Result;
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ResponseType>(jsonData);
            return data;
        }
    }
}
