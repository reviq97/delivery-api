using delivery_api.Models;
using FluentValidation;

namespace delivery_api.Validators
{
    public class CourierDtoValidator : AbstractValidator<CourierDto>
    {
        public CourierDtoValidator()
        {
            RuleFor(x => x.PESEL)
                .NotEmpty()
                .Custom((pesel, fail) =>
                {
                    var currentYear = int.Parse(DateTime.Now.Year.ToString().Substring( 2 ));
                    var birthYear = int.Parse(pesel.Substring(0, 2));

                    if((birthYear > 0 && birthYear < currentYear) && (currentYear - birthYear) < 18)
                    {
                        fail.AddFailure("PESEL", "Courier is too young");
                    }

                    if(pesel.Length != 11)
                    {
                        fail.AddFailure("PESEL", "PESEL should have 11 characters");
                    }
                });
        }
    }
}
