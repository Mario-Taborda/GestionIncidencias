using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GestionIncidencias.Web.Service
{
    public class RequestService(HttpClient httpClient, IJSRuntime js) : IRequestService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IJSRuntime js = js;
        public static readonly string TOKENKEY = "TOKENKEY";

        private static JsonSerializerOptions JsonDefaultOptions => new()
        {
            PropertyNameCaseInsensitive = true,
        };

     
        public async Task<T> GetTAsync<T>(string url)
        {
           
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, JsonDefaultOptions)!;
        }

      
        public async Task<T> GetByIdAsync<T>(string url, int id)
        {
            
            var requestUrl = $"{url}/{id}";
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, JsonDefaultOptions)!;
        }

     
        public async Task<HttpResponseMessage> PostAsync<T>(string url, T model)
        {
            
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(url, content);
        }

     
        public async Task<HttpResponseMessage> PostWithoutAuthAsync<T>(string url, T model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(url, content);
        }

 
        public async Task<bool> DeleteAsync(string url)
        {
            
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }


        public async Task<HttpResponseMessage> PutAsync<T>(string url, T model)
        {
            
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync(url, content);
        }
    }
}

