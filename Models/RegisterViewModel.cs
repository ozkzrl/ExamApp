using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email gereklidir")]
    [EmailAddress(ErrorMessage = "Geçersiz email formatı")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir")]
    [StringLength(100, ErrorMessage = "Şifre en az {2} en fazla {1} karakter olmalı", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
    public string ConfirmPassword { get; set; }
}