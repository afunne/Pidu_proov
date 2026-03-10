using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pidu_proov.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "E-post on kohustuslik.")]
        [Display(Name = "E-post")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "Teenusepakkuja on kohustuslik.")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Kood on kohustuslik.")]
        [Display(Name = "Kood")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Mäleta seda brauserit?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-post on kohustuslik.")]
        [Display(Name = "E-post")]
        [EmailAddress(ErrorMessage = "Palun sisesta korrektne e-posti aadress.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parool on kohustuslik.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parool")]
        public string Password { get; set; }

        [Display(Name = "Mäleta mind?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "E-post on kohustuslik.")]
        [EmailAddress(ErrorMessage = "Palun sisesta korrektne e-posti aadress.")]
        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parool on kohustuslik.")]
        [StringLength(100, ErrorMessage = "{0} peab olema vähemalt {2} tähemärki pikk.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parool")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kinnita parool")]
        [Compare("Password", ErrorMessage = "Parool ja kinnitusparool ei ühti.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "E-post on kohustuslik.")]
        [EmailAddress(ErrorMessage = "Palun sisesta korrektne e-posti aadress.")]
        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parool on kohustuslik.")]
        [StringLength(100, ErrorMessage = "{0} peab olema vähemalt {2} tähemärki pikk.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parool")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kinnita parool")]
        [Compare("Password", ErrorMessage = "Parool ja kinnitusparool ei ühti.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-post on kohustuslik.")]
        [EmailAddress(ErrorMessage = "Palun sisesta korrektne e-posti aadress.")]
        [Display(Name = "E-post")]
        public string Email { get; set; }
    }
}
