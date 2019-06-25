using System;
using System.Collections.Generic;
using System.Text;

namespace saaz.Catalog.App.Models
{
    public class CatalogItemListViewModel
    {
        public IEnumerable<CatalogItemViewModel> CatalogItems { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
