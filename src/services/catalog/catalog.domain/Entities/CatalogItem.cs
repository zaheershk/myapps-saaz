using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.domain.Entities
{
    public class CatalogItem : CatalogBase
    {
        public int TypeId { get; set; } //refers Id field in CatalogType model
        public int BrandId { get; set; } //refers Id field in CatalogBrand model
        public int CategoryId { get; set; } //refers Id field in CatalogCategory model
        public int? SubCategoryId { get; set; } //refers Id field in CatalogSubCategory model
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal? Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public int? AvailableStock { get; set; }
        public int? RestockThreshold { get; set; }
        public int? MaxStockThreshold { get; set; }

        public CatalogType Type { get; set; }
        public CatalogBrand Brand { get; set; }
        public CatalogCategory Category { get; set; }
        public CatalogSubCategory SubCategory { get; set; }
    }
}