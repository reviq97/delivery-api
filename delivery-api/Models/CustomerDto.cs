using System.ComponentModel.DataAnnotations;

namespace delivery_api.Models
{
    public class CustomerDto
    {
        private string _postalCode;
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
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = $"{value[0]}{value[1]}-{value[2]}{value[3]}{value[4]}";
            }
        }
        [Required]
        public string City { get; set; }

    }
}
