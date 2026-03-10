using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Pidu_proov.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "Parool on kohustuslik.")]
        [StringLength(100, ErrorMessage = "{0} peab olema vähemalt {2} tähemärki pikk.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Uus parool")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kinnita uus parool")]
        [Compare("NewPassword", ErrorMessage = "Uus parool ja kinnitusparool ei ühti.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Praegune parool on kohustuslik.")]
        [DataType(DataType.Password)]
        [Display(Name = "Praegune parool")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Uus parool on kohustuslik.")]
        [StringLength(100, ErrorMessage = "{0} peab olema vähemalt {2} tähemärki pikk.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Uus parool")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kinnita uus parool")]
        [Compare("NewPassword", ErrorMessage = "Uus parool ja kinnitusparool ei ühti.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required(ErrorMessage = "Telefoninumber on kohustuslik.")]
        [Phone(ErrorMessage = "Palun sisesta korrektne telefoninumber.")]
        [Display(Name = "Telefoninumber")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required(ErrorMessage = "Kood on kohustuslik.")]
        [Display(Name = "Kood")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Telefoninumber on kohustuslik.")]
        [Phone(ErrorMessage = "Palun sisesta korrektne telefoninumber.")]
        [Display(Name = "Telefoninumber")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}