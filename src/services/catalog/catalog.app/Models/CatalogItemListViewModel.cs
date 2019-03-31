using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.app.Models
{
    public class CatalogItemListViewModel
    {
        public IEnumerable<CatalogItemViewModel> CatalogItems { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
