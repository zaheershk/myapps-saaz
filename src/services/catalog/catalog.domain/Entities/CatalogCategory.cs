using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.domain.Entities
{
    public class CatalogCategory : CatalogBase
    {
        public CatalogCategory()
        {
            SubCategories = new HashSet<CatalogSubCategory>();
            CatalogItems = new HashSet<CatalogItem>();
        }

        public string CategoryName { get; set; }

        //fk-fields
        public ICollection<CatalogSubCategory> SubCategories { get; private set; }
        public ICollection<CatalogItem> CatalogItems { get; private set; }
    }
}
