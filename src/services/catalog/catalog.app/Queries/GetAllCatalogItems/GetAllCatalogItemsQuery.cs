using saaz.Catalog.App.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace saaz.Catalog.App.Queries.GetAllCatalogItems
{
    public class GetAllCatalogItemsQuery : IRequest<CatalogItemListViewModel>
    {
    }
}
