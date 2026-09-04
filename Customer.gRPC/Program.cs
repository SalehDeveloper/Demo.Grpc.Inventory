

using Customer.gRPC.Data;
using Customer.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<CustomerService>();
app.Run();
