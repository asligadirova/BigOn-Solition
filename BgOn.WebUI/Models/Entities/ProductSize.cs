using BgOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BgOn.WebUI.Models.Entities
{
    public class ProductSize: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string SmallName { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalogItem { get; set; }
    }
}
