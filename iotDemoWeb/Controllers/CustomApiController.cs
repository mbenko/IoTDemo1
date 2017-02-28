using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;

namespace iotDemoWeb.Controllers
{
    [MobileAppController]
    public class CustomApiController : ApiController
    {
        // GET api/CustomApi
        public string Get(string name, string role, string owner="Mike")
        {
            return $"Hello {name} from custom controller!";
        }
    }
}
