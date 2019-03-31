using System;
using System.Collections.Generic;
using System.Text;

namespace catalog.domain.Entities
{
    public abstract class CatalogBase
    {
        public int Id { get; set; }        
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
