using System.ComponentModel.DataAnnotations;

namespace TelerikAcademy.TripyMate.Web.Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}