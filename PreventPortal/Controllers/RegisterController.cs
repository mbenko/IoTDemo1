using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace PreventPortal.Controllers
{
    [MobileAppController]
    public class RegisterController : ApiController
    {
        // GET api/Register
        public string Get(string name)
        {
            return "Hello from custom controller!";
        }
    }
}
