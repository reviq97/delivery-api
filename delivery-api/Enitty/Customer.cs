using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace delivery_api.Enitty
{
    public class Customer
    {
        private string _postalCode;
        [Required]
        [Key]
        public string CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [MaxLength(6)]
        [DataType(DataType.PostalCode)]
        public string PostalCode 
        {
            get { return _postalCode; }
            set { _postalCode = string.Format("{0:##-###}", int.Parse(value)); }
        }
        [Required]
        public string City { get; set; }

    }
}
