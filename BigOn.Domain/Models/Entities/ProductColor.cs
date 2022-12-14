using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class ProductColor: BaseEntity
    {
        public string Name { get; set; }
        public string Hex { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalogItem { get; set; }
    }
}
