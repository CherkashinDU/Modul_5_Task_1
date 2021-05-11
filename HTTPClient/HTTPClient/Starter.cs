using System;
using System.Threading.Tasks;
using HTTPClient.Services;

namespace HTTPClient
{
    public class Starter
    {
        public Task Run()
        {
            return Task.WhenAll(
                LocatorService.UserService.GetPage(1, 6),
                LocatorService.UserService.Get(2),
                LocatorService.UserService.Get(23),
                LocatorService.ResourceService.GetPage(1, 6),
                LocatorService.ResourceService.Get(2),
                LocatorService.ResourceService.Get(23),
                LocatorService.UserService.Create("Test User", "IT"),
                LocatorService.UserService.UpdatePut(2, "morpheus", "zion resident"),
                LocatorService.UserService.UpdatePatch(2, "morpheus2", "zion resident"),
                LocatorService.UserService.Delete(2),
                LocatorService.RegisterService.Register("eve.holt@reqres.in", "pistol"),
                LocatorService.RegisterService.Register("sydney@fife", null),
                LocatorService.LoginService.Login("eve.holt@reqres.in", "cityslicka"),
                LocatorService.LoginService.Login("peter@klaven", " "),
                LocatorService.UserService.Delay(3));
        }
    }
}
