using System.Net.Http;
using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpHelper _httpHelper;
        private readonly Settings _settings;

        public LoginService()
        {
            var configurationService = new ConfigurationService();
            _settings = configurationService.GetSettings();
            _httpHelper = new HttpHelper();
        }

        public async Task<LoginResponseModel> Login(string email, string password)
        {
            var url = $"{_settings.LoginApiUrl}";
            var credential = new LoginRequestModel { Email = email, Password = password };
            var response = await _httpHelper.Send<LoginResponseModel>(url, HttpMethod.Post, credential);
            return response;
        }
    }
}
