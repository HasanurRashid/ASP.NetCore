using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Models
{
    public class TestModel
    {
        [Required, EmailAddress(ErrorMessage = "Please provide valid email"), Display(Name = "Email Address")]
        public string? Email { get; set; }
       
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
