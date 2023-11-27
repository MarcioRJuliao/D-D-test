using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using dandd.Models;
using dandd.ViewModels;
using dandd.Views;

namespace dandd.Services
{
    public class RaceService
    {
        private HttpClient _client;

        private JsonSerializerOptions _serializerOptions;
        private const string baseUrl = "https://www.dnd5eapi.co/api/";

        public RaceService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<Race>> GetRacesAsync()
        {
            var url = $"{baseUrl}/races";

            try
            {
                var response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<Race>>(content, _serializerOptions);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
