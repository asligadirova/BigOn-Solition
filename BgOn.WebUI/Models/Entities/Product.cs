using BgOn.WebUI.AppCode.Infrastructure;

namespace BgOn.WebUI.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }
}
