using System.Net.Http;
using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpHelper _httpHelper;
        private readonly Settings _settings;

        public RegisterService()
        {
            var configurationService = new ConfigurationService();
            _settings = configurationService.GetSettings();
            _httpHelper = new HttpHelper();
        }

        public async Task<RegisterResponseModel> Register(string email, string password)
        {
            var url = $"{_settings.RegisterApiUrl}";
            var credential = new RegisterRequestModel { Email = email, Password = password };
            var response = await _httpHelper.Send<RegisterResponseModel>(url, HttpMethod.Post, credential);
            return response;
        }
    }
}
