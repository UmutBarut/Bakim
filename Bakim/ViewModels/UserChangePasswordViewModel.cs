using System.ComponentModel.DataAnnotations;

namespace Bakim.ViewModels
{
    public class UserChangePasswordViewModel
    {
        [Display(Name = "Eski şifreniz")]
        public string OldPassword { get; set; }
        [Display(Name = "Yeni şifreniz")]
        public string NewPassword { get; set; }
        [Display(Name = "Yeni şifrenizi tekrar yazın")]
        [Compare("NewPassword", ErrorMessage = "Şifreler Uyuşmuyor.")]
        public string NewPasswordRepeat { get; set; }
    }
}
