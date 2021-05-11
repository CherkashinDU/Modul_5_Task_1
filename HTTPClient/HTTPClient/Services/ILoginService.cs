using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient.Services
{
    public interface ILoginService
    {
        Task<LoginResponseModel> Login(string email, string password);
    }
}
