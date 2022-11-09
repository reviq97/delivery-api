using delivery_api.Models;
using FluentValidation;

namespace delivery_api.Validators
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Email).NotEmpty()
                .EmailAddress();

            RuleFor(x => x.PostalCode)
                .Custom((postalCode, fail) =>
                {
                    if(postalCode.Length != 6 || postalCode.Length < 6)
                    {
                        fail.AddFailure("PostalCode", $"Should have exactly 6 characters, already has {postalCode.Length}");
                    }

                });
        }
    }
}
