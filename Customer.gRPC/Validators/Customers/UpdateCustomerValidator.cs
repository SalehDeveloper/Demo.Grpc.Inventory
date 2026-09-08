using Customer.gRPC.Protos;
using FluentValidation;

namespace Customer.gRPC.Validators.Customers
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
                

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .Must(dob => dob.ToDateTime() < DateTime.UtcNow);
               
        }
    }
}
