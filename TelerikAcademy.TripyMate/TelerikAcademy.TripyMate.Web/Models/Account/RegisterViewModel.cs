using System.ComponentModel.DataAnnotations;

namespace TelerikAcademy.TripyMate.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "The phone number is in incorrect length", MinimumLength = 10)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter your name")]
        [MinLength(3, ErrorMessage = "Your name must be at least 3 symbols long!")]
        [MaxLength(25, ErrorMessage = "Your name must be at least 25 symbols long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name!")]
        [MinLength(3, ErrorMessage = "Your name must be at least 3 symbols long!")]
        [MaxLength(25, ErrorMessage = "Your name must be at least 25 symbols long!")]
        public string LastName { get; set; }
    }
}