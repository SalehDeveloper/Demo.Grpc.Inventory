using Customer.gRPC.Data;
using Customer.gRPC.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Customer.gRPC.Services
{
    public class CustomerService(CustomerDbContext dbcontext) : Customer.gRPC.Protos.Customer.CustomerBase
    {

        public override async Task<CreateCustomerResponse> Create(CreateCustomerRequest request, ServerCallContext context)
        {

            await dbcontext.Customers.AddAsync(Customer.gRPC.Data.Customer.Create(
                request.Name,
                request.Address,
                request.DateOfBirth.ToDateTime(),
                request.SecondaryAddress));

            await dbcontext.SaveChangesAsync();

            return await Task.FromResult(new CreateCustomerResponse { Message = "Customer created successfully" });




        }


        public override async Task<GetCustomerResponse> GetCustomer(GetCustomerRequest request, ServerCallContext context)
        {
            var customerId = Guid.Parse(request.Id);
            var customer = await dbcontext.Customers.FindAsync(customerId);

            if (customer == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Customer with ID {request.Id} not found."));
            }


            return new GetCustomerResponse
            {
                Id = customer.Id.ToString(),
                Name = customer.Name,
                Address = customer.Address,
                DateOfBirth = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(customer.DateOfBirth.ToUniversalTime()),
                SecondaryAddress = customer.SecondaryAddress
            };

        }

        public override async Task<GetCustomersResponse> GetCustomers(GetCustomersRequest request, ServerCallContext context)
        {
            var customers = await dbcontext.Customers.ToListAsync();

            var response = new GetCustomersResponse();

            response.Customers.AddRange(customers.Select(customer => new GetCustomerResponse
            {
                Id = customer.Id.ToString(),
                Name = customer.Name,
                Address = customer.Address,
                DateOfBirth = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(customer.DateOfBirth.ToUniversalTime()),
                SecondaryAddress = customer.SecondaryAddress
            }));

            return response;
        }

        public override async Task<UpdateCustomerResponse> UpdateCustomer(UpdateCustomerRequest request, ServerCallContext context)
        {
            var customerId = Guid.Parse(request.Id);
            var customer = await dbcontext.Customers.FindAsync(customerId);

            if (customer == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Customer with ID {request.Id} not found."));
            }

            customer.Update(
                request.Name,
                request.Address,
                request.DateOfBirth.ToDateTime(),
                request.SecondaryAddress);

            await dbcontext.SaveChangesAsync();

            return new UpdateCustomerResponse { Message = "Customer updated successfully" };
        }
    }
}