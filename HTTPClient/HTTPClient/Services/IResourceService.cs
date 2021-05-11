using System.Threading.Tasks;
using HTTPClient.Models;

namespace HTTPClient.Services
{
    public interface IResourceService
    {
        Task<ResourceModel> Get(int id);
        Task<ResourceModel[]> GetPage(int pageIndex, int pageSize);
    }
}
