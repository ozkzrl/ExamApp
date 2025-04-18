using System.ComponentModel.DataAnnotations;

namespace MyMvcExamProject.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yeni şifre gereklidir.")]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre (Tekrar)")]
        [Compare("Password", ErrorMessage = "Yeni şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
