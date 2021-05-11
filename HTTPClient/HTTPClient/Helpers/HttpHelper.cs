using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HTTPClient
{
    public class HttpHelper
    {
        private const int _timeout = 120;

        public async Task<TResponse> Send<TResponse>(string url, HttpMethod method, object data = null)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(_timeout);

                var request = new HttpRequestMessage(method, url);
                if (data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }

                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResponse>(content);
                }
                else
                {
                    Console.WriteLine($"Request error message: {content} StatusCode: {(int)response.StatusCode}");
                    return default(TResponse);
                }
            }
        }

        public async Task<bool> Send(string url, HttpMethod method)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(method, url);
                var response = await httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request error message: {content} StatusCode: {(int)response.StatusCode}");
                }

                return response.IsSuccessStatusCode;
            }
        }
    }
}
