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
    public class ParentController : TableController<Parent>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Parent>(context, Request, Services);
        }

        // GET tables/Parent
        [AuthorizeLevel(Microsoft.WindowsAzure.Mobile.Service.Security.AuthorizationLevel.Anonymous)]
        public IQueryable<Parent> GetAllParent()
        {
            return Query(); 
        }

        // GET tables/Parent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Parent> GetParent(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Parent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Parent> PatchParent(string id, Delta<Parent> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Parent
        public async Task<IHttpActionResult> PostParent(Parent item)
        {
            Parent current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Parent/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteParent(string id)
        {
             return DeleteAsync(id);
        }

    }
}