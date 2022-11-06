using System.ComponentModel.DataAnnotations;

namespace delivery_api.Enitty
{
    public class Courier
    {
        [Required]
        [Key]
        public string CourierId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [MaxLength(11)]
        [RegularExpression("([0-9]+", ErrorMessage = "Please enter valid number")]
        private string _pesel;
        public string PESEL
        {
            get { return _pesel; }
            set
            {
                var currentYear = int.Parse(DateTime.Now.Year.ToString().Substring(2));
                var birthYear = int.Parse(value.Substring(0, 2));

                if((birthYear > 0 && birthYear < currentYear) && (currentYear - birthYear) < 18)
                {
                    throw new Exception("Too young");
                }
                _pesel = value;
            }
        }

    }
}
