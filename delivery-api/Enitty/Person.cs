using System.ComponentModel.DataAnnotations;

namespace delivery_api.Enitty
{
    public class Person
    {
        [Required]
        public string PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }

    }
}
