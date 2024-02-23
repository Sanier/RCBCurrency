using RCBCurrency.JSON.Interfaces;

namespace RCBCurrency.JsonDeserialize
{
    public class LoadJson : ILoadJson
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task LoadJsonToFile()
        {
            string pathToJson = @"./Currencies.json";
            string RCBUrl = "https://www.cbr-xml-daily.ru/daily_json.js";

            //Update information
            var response = await _httpClient.GetAsync(RCBUrl);

            if (response.IsSuccessStatusCode)
                await File.WriteAllBytesAsync(pathToJson, await response.Content.ReadAsByteArrayAsync());
        }
    }
}
