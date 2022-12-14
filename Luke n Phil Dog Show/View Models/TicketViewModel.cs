using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Luke_n_Phil_Dog_Show.View_Models
{
    public class TicketViewModel
    {
        public IEnumerable<SelectListItem>? EventList { get; set; }

        public string? EventSelected { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength =2)]
        public string State { get; set; }

        [Required]
        [StringLength (5, MinimumLength =5)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [CreditCard]
        [DisplayName("Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [StringLength(3, MinimumLength =3)]
        public string CVV { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [DisplayName("Expiration Month (MM)")]
        public string ExpirationMonth { get; set; }

        [Required]
        [StringLength(2,MinimumLength = 2)]
        [DisplayName("Expiration Year (YY)")]
        public string ExpirationYear { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
