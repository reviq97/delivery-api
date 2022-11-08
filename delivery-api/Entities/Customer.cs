using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace delivery_api.Enitty
{
    public class Customer
    {
        [Required]
        [Key]
        public string CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(6)]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }

    }
}
