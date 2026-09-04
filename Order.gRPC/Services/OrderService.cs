
using Customer.gRPC.Protos;
using Grpc.Core;
using Order.gRPC.Data;
using Order.gRPC.Protos;
namespace Order.gRPC.Services;

public class OrderService(OrderDbContext dbContext , Customer.gRPC.Protos.Customer.CustomerClient client) : Order.gRPC.Protos.Order.OrderBase
{
    public override async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, ServerCallContext context)
    {

        var customer = client.GetCustomer(new GetCustomerRequest { Id = request.CustomerId });


        if (customer == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Customer with ID {request.CustomerId} not found."));
        }

        var order = gRPC.Data.Order.Create(
            Guid.Parse(customer.Id),
            customer.Name,
            request.Quantity,
            (decimal)request.Price,
            DateTime.UtcNow);


        await dbContext.Orders.AddAsync(order);

        await dbContext.SaveChangesAsync();

        return new CreateOrderResponse
        {
            OrderId = order.Id.ToString(),
            CustomerId = request.CustomerId,
            Message = Resources.OrderRes.product
        };


    }
}
