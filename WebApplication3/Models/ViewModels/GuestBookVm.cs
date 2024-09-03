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

        [Display(Name="姓名")]
        public string Name { get; set; }

        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Display(Name = "留言時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]

        public DateTime CreateTime { get; set; }
    }
}