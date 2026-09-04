using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Globalization;

namespace Order.gRPC.Interceptors
{
    public sealed  class LanguageInterceptor : Interceptor
    {

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {

          
            var language = context.RequestHeaders.GetValue("language");

            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(language);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            return await continuation(request, context);


         
        }
    }
}
