using System.ComponentModel.DataAnnotations;

namespace delivery_api.Enitty
{
    public class Courier
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression("([0-9]+", ErrorMessage = "Please enter valid number")]
        public uint PESEL
        {
            get { return PESEL; }
            set 
            {
                if(value >= 18) PESEL = value;
            }
        }

    }
}
