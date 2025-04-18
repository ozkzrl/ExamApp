using System.ComponentModel.DataAnnotations;

namespace MyMvcExamProject.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Eski şifre gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Eski Şifre")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre gereklidir.")]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre tekrar gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre (Tekrar)")]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
