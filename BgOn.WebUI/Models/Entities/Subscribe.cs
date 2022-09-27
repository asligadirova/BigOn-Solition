using BgOn.WebUI.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace BgOn.WebUI.Models.Entities
{
    public class Subscribe: BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime? ApprovedData { get; set; }
        public bool IsApproved { get; set; }=false;
    }
}
