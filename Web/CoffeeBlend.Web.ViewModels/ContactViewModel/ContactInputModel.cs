﻿namespace CoffeeBlend.Web.ViewModels.ContactViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class ContactInputModel
    {
        [Required]
        [MinLength(5)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Subject { get; set; }

        [Required]
        [MinLength(10)]
        public string Message { get; set; }
    }
}
