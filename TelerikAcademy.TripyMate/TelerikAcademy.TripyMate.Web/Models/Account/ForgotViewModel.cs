using System.ComponentModel.DataAnnotations;

namespace TelerikAcademy.TripyMate.Web.Models.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}