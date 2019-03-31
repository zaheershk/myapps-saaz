using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using catalog.app.Models;
using catalog.data;

namespace catalog.app.Queries.GetAllCatalogItems
{
    public class GetAllCatalogItemsQueryHandler : IRequestHandler<GetAllCatalogItemsQuery, CatalogItemListViewModel>
    {
        private readonly CatalogDbContext _context;

        public GetAllCatalogItemsQueryHandler(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<CatalogItemListViewModel> Handle(GetAllCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            var catalogItems = await _context.CatalogItem.OrderBy(p => p.ItemName).ToListAsync(cancellationToken);

            return new CatalogItemListViewModel
            {
                //TODO - use automapper
                CatalogItems = from ci in catalogItems
                               select new CatalogItemViewModel
                               {
                                   Id = ci.Id,
                                   TypeId = ci.TypeId,
                                   BrandId = ci.BrandId,
                                   CategoryId = ci.CategoryId,
                                   SubCategoryId = ci.SubCategoryId,
                                   ItemName = ci.ItemName,
                                   ItemDesc = ci.ItemDesc,
                                   Price = ci.Price
                               }, 
                CreateEnabled = true
            };
        }
    }
}
