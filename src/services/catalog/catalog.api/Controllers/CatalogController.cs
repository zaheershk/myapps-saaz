using System.Threading.Tasks;
using catalog.app.Models;
using catalog.app.Queries.GetAllCatalogItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace catalog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger _logger;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());        

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<CatalogItemListViewModel>> GetAll()
        {
            _logger.LogInformation("invoke query : start");
            return Ok(await Mediator.Send(new GetAllCatalogItemsQuery()));
        }
    }
}