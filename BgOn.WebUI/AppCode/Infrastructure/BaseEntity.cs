﻿using System;

namespace BgOn.WebUI.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.UtcNow.AddHours(4);

        public DateTime? DeletedDate { get; set; }
    }
}
