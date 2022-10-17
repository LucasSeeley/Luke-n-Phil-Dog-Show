using System.ComponentModel.DataAnnotations;

namespace Luke_n_Phil_Dog_Show.View_Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
