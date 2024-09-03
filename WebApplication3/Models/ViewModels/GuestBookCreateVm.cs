using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels
{
    public class GuestBookCreateVm
    {
        public int Id { get; set; }

        [Display(Name = "姓名")]
        //[Required(ErrorMessage ="{0}必填")]
        [StringLength(50,ErrorMessage ="{0}長度不可大於{1}")]
        public string Name { get; set; }


        [Display(Name = "電子郵件")]
        //[Required(ErrorMessage = "{0}必填")]
        //[EmailAddress(ErrorMessage = "{0}格式必填")]
        [StringLength(254, ErrorMessage = "{0}長度不可大於{1}")]
 
        public string Email { get; set; }

        [Display(Name = "手機")]
        //[Required(ErrorMessage = "{0}必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可大於{1}")]
        public string CellPhone { get; set; }

        [Display(Name = "留言")]
        //[Required(ErrorMessage = "{0}必填")]
        [StringLength(200, ErrorMessage = "{0}長度不可大於{1}")]
        public string Message { get; set; }

        [Display(Name = "附件")]
        public string FileName { get; set; }    

    }
}