using System.Net.Http;
using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient.Services
{
    public class ResourceService : IResourceService
    {
        private readonly HttpHelper _httpHelper;
        private readonly Settings _settings;

        public ResourceService()
        {
            var configurationService = new ConfigurationService();
            _settings = configurationService.GetSettings();
            _httpHelper = new HttpHelper();
        }

        public async Task<ResourceModel> Get(int id)
        {
            var url = $"{_settings.ResourceApiUrl}/{id}";
            var response = await _httpHelper.Send<SingleResourceResponseModel>(url, HttpMethod.Get);
            return response?.Data;
        }

        public async Task<ResourceModel[]> GetPage(int pageIndex, int pageSize)
        {
            var url = $"{_settings.ResourceApiUrl}?page={pageIndex}&per_page={pageSize}";
            var response = await _httpHelper.Send<ResourceListResponseModel>(url, HttpMethod.Get);
            return response?.Data;
        }
    }
}
