using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient
{
    public interface IUserService
    {
        Task<UserModel> Get(int id);
        Task<UserModel[]> GetPage(int pageIndex, int pageSize);
        Task<UserCreateResponseModel> Create(string name, string job);
        Task<UserUpdateResponseModel> UpdatePut(int id, string name, string job);
        Task<UserUpdateResponseModel> UpdatePatch(int id, string name, string job);
        Task<bool> Delete(int id);
        Task<UserModel[]> Delay(int delay);
    }
}
