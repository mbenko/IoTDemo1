using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using iotDemoWeb.Models;

namespace iotDemoWeb.Controllers
{
    public class iotDeviceController : TableController<iotDevice>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            iotDemoWebContext context = new iotDemoWebContext();
            DomainManager = new EntityDomainManager<iotDevice>(context, Request);
        }

        // GET tables/iotDevice
        public IQueryable<iotDevice> GetAlliotDevice()
        {
            return Query(); 
        }

        // GET tables/iotDevice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<iotDevice> GetiotDevice(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/iotDevice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<iotDevice> PatchiotDevice(string id, Delta<iotDevice> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/iotDevice
        public async Task<IHttpActionResult> PostiotDevice(iotDevice item)
        {
            iotDevice current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/iotDevice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteiotDevice(string id)
        {
             return DeleteAsync(id);
        }
    }
}
