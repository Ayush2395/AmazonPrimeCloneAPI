using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;

namespace AmazonPrimeClone.Web.Extensions;

public static class SerilogExtention
{
    public static IServiceCollection AddApplicationLogService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog(config =>
        {
            var options = new MSSqlServerSinkOptions
            {
                AutoCreateSqlTable = true,
                SchemaName = "Logs",
                TableName = "ApplicationLogs",
                UseSqlBulkCopy = true,
            };
            config.MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.MSSqlServer(configuration.GetConnectionString("DefaultConnection"), options);
        });
        return services;
    }
}
