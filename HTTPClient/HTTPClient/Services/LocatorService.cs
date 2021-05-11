using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    public static class LocatorService
    {
        public static IUserService UserService => new UserService();
        public static IResourceService ResourceService => new ResourceService();
        public static IRegisterService RegisterService => new RegisterService();
        public static ILoginService LoginService => new LoginService();
    }
}
