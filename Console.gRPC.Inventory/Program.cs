

using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;

var chaneel = GrpcChannel.ForAddress("http://localhost:5108");

var client = new Order.gRPC.Protos.Order.OrderClient(chaneel);

var createOrderRequest = new Order.gRPC.Protos.CreateOrderRequest
{
    CustomerId = "9FC9E2DC-3909-4EBE-99C9-ADB561B75600",
    Price = 1.2,
    ProductName = "Laptop",
    Quantity = 2
};


var lanRequest = new Order.gRPC.Protos.LanguageData
{
    LanguageCode = "ar"
};


var metadata = new Metadata
{
    { "language-bin", lanRequest.ToByteArray() }
};


var call = client.CreateOrderAsync(createOrderRequest, metadata);

var res = await call.ResponseAsync;

var trailers = call.GetTrailers();

var responseTime = trailers.GetValue("X-Response-Time");
Console.WriteLine($" orderId: {res.OrderId}\n customerId: {res.CustomerId}\n message: {res.Message} \n responseTime: {responseTime}");


Console.ReadKey();