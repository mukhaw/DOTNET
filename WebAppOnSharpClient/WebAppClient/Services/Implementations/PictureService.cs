using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class PictureService:IPictureService
    {
        private HttpClient HttpClient { get; }
        
        public PictureService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Picture>> GetPicture()
        {
            using var response = await this.HttpClient.GetAsync("api/picture");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Picture>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Picture> GetPicture(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/picture/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Disease>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Picture> PutPicture(Picture picture)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(picture), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/picture",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Disease>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Picture> PatchPicture(Picture picture)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(disease), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/picture",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Disease>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}