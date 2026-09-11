using Grpc.Core;
using Grpc.Core.Interceptors;
using Order.gRPC.Protos;
using System.Globalization;

namespace Order.gRPC.Interceptors
{
    public sealed class LanguageInterceptor : Interceptor
    {

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {

            var header = context.RequestHeaders.SingleOrDefault(e => e.Key == "language-bin");

            if (header == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Language header is missing."));
            }
            var lan = LanguageData.Parser.ParseFrom(header.ValueBytes);

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(lan.LanguageCode);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(lan.LanguageCode);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lan.LanguageCode);

            return await continuation(request, context);



        }


    }
}
