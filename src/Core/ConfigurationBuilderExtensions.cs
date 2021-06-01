using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Core
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddConfigurations(this IConfigurationBuilder builder, HostBuilderContext ctx)
        {
            var env = ctx.HostingEnvironment;
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(Path.Combine("Configurations", "appsettings.json"), optional: true, reloadOnChange: true)
                   .AddJsonFile(Path.Combine("Configurations", $"appsettings.{env.EnvironmentName}.json"), optional: true, reloadOnChange: true);
            return builder;
        }
    }
}
