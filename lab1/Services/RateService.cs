using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NbrbAPI.Models;

namespace lab1.Services
{
    public class RateService : IRateService
    {
        private HttpClient _httpClient = new HttpClient();
        public RateService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<IEnumerable<Rate>?> GetRates(DateTime date)
        {
            var response = await _httpClient.GetAsync($"https://api.nbrb.by/exrates/rates?ondate={date.ToString("yyyy-MM-dd")}&periodicity=0");
            if (!response.IsSuccessStatusCode) return null;
            return await JsonSerializer.DeserializeAsync<IEnumerable<Rate>>(await response.Content.ReadAsStreamAsync());
        }
    }
}
