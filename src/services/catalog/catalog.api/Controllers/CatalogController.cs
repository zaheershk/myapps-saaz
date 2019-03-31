using System.Threading.Tasks;
using catalog.app.Models;
using catalog.app.Queries.GetAllCatalogItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace catalog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        [HttpGet]
        public async Task<ActionResult<CatalogItemListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCatalogItemsQuery()));
        }
    }
}