using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class OwnerService: IOwnerService
    {
        private HttpClient HttpClient { get; }
        
        public OwnerService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Owner>> GetOwner()
        {
            using var response = await this.HttpClient.GetAsync("api/owner");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Owner>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Owner> GetOwner(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/owner/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Owner>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Owner> PutOwner(Owner owner)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(owner), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/owner",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Owner>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Owner> PatchOwner(Owner owner)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(owner), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/owner",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Owner>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}