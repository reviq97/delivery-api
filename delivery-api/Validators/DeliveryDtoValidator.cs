using delivery_api.Models;
using FluentValidation;

namespace delivery_api.Validators
{
    public class DeliveryDtoValidator : AbstractValidator<DeliveryDto>
    {
        public DeliveryDtoValidator()
        {
            RuleFor(x => x.Sender.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Sender.Name).NotEmpty();
            RuleFor(x => x.Sender.Surname).NotEmpty();
            RuleFor(x => x.Sender.City).NotEmpty();

            RuleFor(x => x.Recipient.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Recipient.Name).NotEmpty();
            RuleFor(x => x.Recipient.Surname).NotEmpty();
            RuleFor(x => x.Recipient.City).NotEmpty();

            RuleFor(x => x.DeliveryDetails).NotEmpty();
        }
    }
    
}
