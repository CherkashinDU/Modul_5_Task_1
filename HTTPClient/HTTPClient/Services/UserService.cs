using System.Threading.Tasks;
using System.Net.Http;
using HTTPClient.Models;

namespace HTTPClient
{
    public class UserService : IUserService
    {
        private readonly HttpHelper _httpHelper;
        private readonly Settings _settings;

        public UserService()
        {
            var configurationService = new ConfigurationService();
            _settings = configurationService.GetSettings();
            _httpHelper = new HttpHelper();
        }

        public async Task<UserModel> Get(int id)
        {
            var url = $"{_settings.UserApiUrl}/{id}";
            var response = await _httpHelper.Send<SingleUserResponseModel>(url, HttpMethod.Get);
            return response?.Data;
        }

        public async Task<UserModel[]> GetPage(int pageIndex, int pageSize)
        {
            var url = $"{_settings.UserApiUrl}?page={pageIndex}&per_page={pageSize}";
            var response = await _httpHelper.Send<UserListResponseModel>(url, HttpMethod.Get);
            return response?.Data;
        }

        public async Task<UserCreateResponseModel> Create(string name, string job)
        {
            var url = _settings.UserApiUrl;
            var user = new UserCreateRequestModel { Job = job, Name = name };
            var response = await _httpHelper.Send<UserCreateResponseModel>(url, HttpMethod.Post, user);
            return response;
        }

        public async Task<UserUpdateResponseModel> UpdatePut(int id, string name, string job)
        {
            var url = $"{_settings.UserApiUrl}/{id}";
            var user = new UserUpdateRequestModel { Job = job, Name = name };
            var response = await _httpHelper.Send<UserUpdateResponseModel>(url, HttpMethod.Put, user);
            return response;
        }

        public async Task<UserUpdateResponseModel> UpdatePatch(int id, string name, string job)
        {
            var url = $"{_settings.UserApiUrl}/{id}";
            var user = new UserUpdateRequestModel { Job = job, Name = name };
            var response = await _httpHelper.Send<UserUpdateResponseModel>(url, HttpMethod.Patch, user);
            return response;
        }

        public Task<bool> Delete(int id)
        {
            var url = $"{_settings.UserApiUrl}/{id}";
            return _httpHelper.Send(url, HttpMethod.Delete);
        }

        public async Task<UserModel[]> Delay(int delay)
        {
            var url = $"{_settings.UserApiUrl}?delay={delay}";
            var response = await _httpHelper.Send<UserListResponseModel>(url, HttpMethod.Get);
            return response?.Data;
        }
    }
}
