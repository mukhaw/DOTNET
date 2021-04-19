using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class CollectionService:ICollectionService
    {
        private HttpClient HttpClient { get; }
        
        public CollectionService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Collection>> GetCollection()
        {
            using var response = await this.HttpClient.GetAsync("api/street");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Collection>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Collection> GetCollection(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/collection/" + id);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Collection>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Collection> PutCollection(Collection collection)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(collection), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/collection",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Collection>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Collection> PatchCollection(Collection collection)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(collection), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/collection",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Collection>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}