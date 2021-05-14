using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseReverseProxy(this IApplicationBuilder builder, IConfiguration configuration)
        {
            var options = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            };
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
            builder.UseForwardedHeaders(options);

            var subdirPath = configuration["SUBDIR"];
            if (!string.IsNullOrWhiteSpace(subdirPath))
                builder.UsePathBase(subdirPath);

            return builder;
        }
    }
}
