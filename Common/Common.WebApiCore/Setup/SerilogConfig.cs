
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.Generic;
using System.Data;

namespace Common.WebApiCore.Setup
{
    public static class SerilogConfig
    {
        public static void Configure(IConfiguration configuration)
        {
            const string logTable = "Logs";
            var connectionString = configuration.GetConnectionString("localDb");

            var columnOptions = new ColumnOptions
            {
                AdditionalDataColumns = new List<DataColumn>
                {
                    new DataColumn("UserId", typeof(int))
                },
            }; 


            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: connectionString,
                    tableName: logTable,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                    autoCreateSqlTable: true,
                    columnOptions: columnOptions
                ).CreateLogger();
        }
    }
}
