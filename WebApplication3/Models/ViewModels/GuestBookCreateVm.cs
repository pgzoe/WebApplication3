using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels
{
    public class GuestBookCreateVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(50)]
        public string CellPhone { get; set; }

        [Required]
        [StringLength(200)]
        public string Message { get; set; }

    }
}