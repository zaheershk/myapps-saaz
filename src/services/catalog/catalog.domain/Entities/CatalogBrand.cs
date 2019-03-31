using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.domain.Entities
{
    public class CatalogBrand : CatalogBase
    {
        public CatalogBrand()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public string BrandName { get; set; }

        //fk-fields
        public ICollection<CatalogItem> CatalogItems { get; private set; }        
    }
}
