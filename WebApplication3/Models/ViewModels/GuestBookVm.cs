using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.ViewModels
{
    public class GuestBookVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        public DateTime CreateTime { get; set; }
    }
}