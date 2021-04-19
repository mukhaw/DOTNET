using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Services.Implementations
{
    public class NoteService:INoteService
    {
        private HttpClient HttpClient { get; }
        
        public NoteService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Note>> GetNote()
        {
            using var response = await this.HttpClient.GetAsync("api/note");
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<IEnumerable<Note>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Note> GetNote(int id)
        {
            using var response = await this.HttpClient.GetAsync("api/note/" + id);
            
            
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Note>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Note> PutNote(Note note)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(note), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PutAsync("api/note",sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Note>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Note> PatchNote(Note note)
        {
            var sendContent = new StringContent( JsonSerializer.Serialize(note), Encoding.UTF8, "application/json");
            using var response = await this.HttpClient.PatchAsync("api/note",sendContent);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<Note>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}