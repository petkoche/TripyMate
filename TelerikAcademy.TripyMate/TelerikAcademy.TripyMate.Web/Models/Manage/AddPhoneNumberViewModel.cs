﻿using System.ComponentModel.DataAnnotations;

namespace TelerikAcademy.TripyMate.Web.Models.Manage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}