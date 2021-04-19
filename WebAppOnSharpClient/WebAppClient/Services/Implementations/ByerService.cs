using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class ByerService:IByerService
    {
        private HttpClient HttpClient { get; }
        
        public ByerService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Byer>> GetByer()
        {
            using var response = await this.HttpClient.GetAsync("api/byer");
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Byer>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Byer> GetByer(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/byer/" + id);
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Byer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Byer> PutByer(Byer byer)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/byer",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Byer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Byer> PatchByer(Byer byer)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(byer), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/byer",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Byer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}