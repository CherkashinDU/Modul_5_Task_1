using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient.Services
{
    public interface IRegisterService
    {
        Task<RegisterResponseModel> Register(string email, string password);
    }
}
