using System;
using System.Collections.Generic;
using System.Text;

namespace saaz.Catalog.App.Models
{
    public class CatalogItemViewModel
    {
        //entity-fields
        public int Id { get; set; }
        public int TypeId { get; set; }        
        public int BrandId { get; set; }        
        public int CategoryId { get; set; }        
        public int? SubCategoryId { get; set; }        
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal? Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public int? AvailableStock { get; set; }
        public int? RestockThreshold { get; set; }
        public int? MaxStockThreshold { get; set; }

        //fk-fields
        public string TypeName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        //ui-flags
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }
    }
}
