using BgOn.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BgOn.WebUI.Models.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
         public virtual ICollection<Product> Products { get; set; }
    }
}
