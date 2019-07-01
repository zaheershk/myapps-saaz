using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using saaz.Catalog.App.Models;
using saaz.Catalog.Data;

namespace saaz.Catalog.App.Queries.GetAllCatalogItems
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
            var catalogItems = await _context.CatalogItems.OrderBy(p => p.ItemName).ToListAsync(cancellationToken);

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
