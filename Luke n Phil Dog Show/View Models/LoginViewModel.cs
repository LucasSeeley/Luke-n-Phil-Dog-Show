using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Luke_n_Phil_Dog_Show.View_Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
