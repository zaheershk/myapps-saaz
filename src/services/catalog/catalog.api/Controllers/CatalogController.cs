using System.Threading.Tasks;
using saaz.Catalog.App.Models;
using saaz.Catalog.App.Queries.GetAllCatalogItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace saaz.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        public CatalogController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<CatalogItemListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCatalogItemsQuery()));
        }
    }
}