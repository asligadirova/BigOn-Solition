using BgOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BgOn.WebUI.Models.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
       public virtual ICollection<ProductCatalogItem> ProductCatalogItem { get; set; }
    }
}
