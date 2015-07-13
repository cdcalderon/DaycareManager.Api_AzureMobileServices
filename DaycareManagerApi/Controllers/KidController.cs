using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using DaycareManagerApi.DataObjects;
using DaycareManagerApi.Models;

namespace DaycareManagerApi.Controllers
{
    public class KidController : TableController<Kid>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Kid>(context, Request, Services);
        }

        // GET tables/Kid
        public IQueryable<Kid> GetAllKid()
        {
            return Query(); 
        }

        // GET tables/Kid/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [AuthorizeLevel(Microsoft.WindowsAzure.Mobile.Service.Security.AuthorizationLevel.Anonymous)]
        public SingleResult<Kid> GetKid(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Kid/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Kid> PatchKid(string id, Delta<Kid> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Kid
        public async Task<IHttpActionResult> PostKid(Kid item)
        {
            Kid current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Kid/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteKid(string id)
        {
             return DeleteAsync(id);
        }

    }
}