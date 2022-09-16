using System;

namespace BgOn.WebUI.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
