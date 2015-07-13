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
     
    public class AssistanceSheetController : TableController<AssistanceSheet>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<AssistanceSheet>(context, Request, Services);
        }

        // GET tables/AssistanceSheet
       [AuthorizeLevel(Microsoft.WindowsAzure.Mobile.Service.Security.AuthorizationLevel.Anonymous)]
        public IQueryable<AssistanceSheet> GetAllAssistanceSheet()
        {
            return Query(); 
        }

        // GET tables/AssistanceSheet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<AssistanceSheet> GetAssistanceSheet(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/AssistanceSheet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<AssistanceSheet> PatchAssistanceSheet(string id, Delta<AssistanceSheet> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/AssistanceSheet
        public async Task<IHttpActionResult> PostAssistanceSheet(AssistanceSheet item)
        {
            AssistanceSheet current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/AssistanceSheet/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAssistanceSheet(string id)
        {
             return DeleteAsync(id);
        }

    }
}