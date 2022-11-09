using System.ComponentModel.DataAnnotations;

namespace delivery_api.Models
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        private string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
            set {
                if(value.Length < 6)
                {
                    _postalCode = "00-000";
                }
                else if (value.Contains("-"))
                {
                    _postalCode = value;
                }
                else if (value.StartsWith("0"))
                {
                    var parsedValue = Convert.ToInt64(value.Insert(0, "1"));
                    _postalCode = string.Format("{0:000-000}", parsedValue).Substring(1);
                }
                else
                {
                    _postalCode = string.Format("{0:00-000}", int.Parse(value));
                }
            }
        }

        public string City { get; set; }

    }
}
