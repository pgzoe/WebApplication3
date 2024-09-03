using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels
{
    public class GuestBookCreateVm
    {
        public int Id { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "電子郵件")]
        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [Display(Name = "手機")]
        [StringLength(50)]
        public string CellPhone { get; set; }

        [Display(Name = "留言")]
        [Required]
        [StringLength(200)]
        public string Message { get; set; }

    }
}