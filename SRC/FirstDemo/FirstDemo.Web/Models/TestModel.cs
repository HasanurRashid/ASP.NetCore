﻿using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Models
{
    public class TestModel
    {
        [Required,EmailAddress(ErrorMessage ="Please enter valid email with @ sign."), Display(Name ="Email Address")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
