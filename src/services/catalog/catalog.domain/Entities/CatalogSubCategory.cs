using System;
using System.Collections.Generic;
using System.Text;

namespace saaz.Catalog.Domain.Entities
{
    public class CatalogSubCategory : CatalogBase
    {
        public CatalogSubCategory()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public int CategoryId { get; set; } //refers Id field in CatalogCategory model
        public string SubCategoryName { get; set; }

        public CatalogCategory Category { get; set; }

        //fk-fields
        public ICollection<CatalogItem> CatalogItems { get; private set; }
    }
}
