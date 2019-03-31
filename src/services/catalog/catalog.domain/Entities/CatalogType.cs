using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.domain.Entities
{
    public class CatalogType : CatalogBase
    {
        public CatalogType()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public string TypeName { get; set; }

        //fk-fields
        public ICollection<CatalogItem> CatalogItems { get; private set; }
    }
}
