using Customer.gRPC.Protos;
using FluentValidation;

namespace Customer.gRPC.Validators.Customers
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .Must(dob => dob.ToDateTime() < DateTime.UtcNow);

        }
    }
}
