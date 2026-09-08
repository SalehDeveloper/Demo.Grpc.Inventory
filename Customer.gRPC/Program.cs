

using Calzolari.Grpc.AspNetCore.Validation;
using Customer.gRPC.Data;
using Customer.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddGrpc();

builder.Services.AddGrpc(options =>
{
    options.EnableMessageValidation();
});

builder.Services.AddGrpcValidation();

builder.Services.AddValidators();


var app = builder.Build();

app.MapGrpcService<CustomerService>();
app.Run();
