using catalog.app.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.app.Queries.GetAllCatalogItems
{
    public class GetAllCatalogItemsQuery : IRequest<CatalogItemListViewModel>
    {
    }
}
