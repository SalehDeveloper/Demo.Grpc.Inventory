using Microsoft.EntityFrameworkCore;
using Order.gRPC.Data;
using Order.gRPC.Interceptors;
using Order.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddGrpc(Option =>
{
    Option.Interceptors.Add<LanguageInterceptor>();
    Option.Interceptors.Add<TimeInterceptor>();

});
builder.Services.AddGrpcClient<Customer.gRPC.Protos.Customer.CustomerClient>(o =>
{
    o.Address = new Uri("http://localhost:5112");
});
var app = builder.Build();

app.MapGrpcService<OrderService>();
app.Run();
