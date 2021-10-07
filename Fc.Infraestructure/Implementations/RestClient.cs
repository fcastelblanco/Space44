using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fc.Infraestructure.Implementations
{
    public class RestClient
    {
        private readonly HttpClient _httpClient;

        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<TOut> Get<TOut>(string requestUri, IDictionary<string, string> aditionalHeaders = null)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (aditionalHeaders != null)
                foreach (var (key, value) in aditionalHeaders)
                    _httpClient.DefaultRequestHeaders.Add(key, value);

            using var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();


            return JsonSerializer.Deserialize<TOut>(responseBody);
        }

        protected async Task<TOut> Post<TOut, TIn>(TIn entity, string requestUri,
            IDictionary<string, string> aditionalHeaders = null)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (aditionalHeaders != null)
                foreach (var aditionalHeader in aditionalHeaders)
                    _httpClient.DefaultRequestHeaders.Add(aditionalHeader.Key, aditionalHeader.Value);

            using var response = await _httpClient.PostAsync(requestUri,
                new StringContent(
                    JsonSerializer.Serialize(entity), Encoding.UTF8,
                    "application/json"));

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TOut>(responseBody);
        }
    }
}
