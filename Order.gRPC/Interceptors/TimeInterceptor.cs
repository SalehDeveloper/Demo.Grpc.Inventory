using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Order.gRPC.Interceptors
{
    public class TimeInterceptor : Interceptor
    {

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var response = await continuation(request, context);

            stopwatch.Stop();

            context.ResponseTrailers.Add("X-Response-Time", stopwatch.ElapsedMilliseconds.ToString());

            return response;


        }
    }
}
