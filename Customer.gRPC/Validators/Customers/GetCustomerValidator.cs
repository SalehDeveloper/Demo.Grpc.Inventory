using Customer.gRPC.Protos;
using FluentValidation;

namespace Customer.gRPC.Validators.Customers
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerRequest>
    {
        public GetCustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

        }
    }
}
