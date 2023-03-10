//using Microsoft.VisualBasic;
//using Serilog;
//using Serilog.Events;
//using Serilog.Sinks.MSSqlServer;
//using System.Collections.ObjectModel;
//using System.Data;

//namespace ECommerce.Serilog
//{
//    public class Serilog
//    {
//        public static void InitializerLoggers(IConfiguration configuration)
//        {
//            Log.Logger = new LoggerConfiguration()
//                 .Enrich.FromLogContext()
//                 .ReadFrom.Configuration(configuration)
//                 .WriteTo.Logger(Logger => ApplySystemLog(Logger, configuration))
//                 .CreateLogger();
//        }

//        [Obsolete]
//        private static void ApplySystemLog(LoggerConfiguration logger, IConfiguration configuration)
//        {
//            string connectionString = configuration.GetConnectionString("ECommerce");
//            LogEventLevel loglevelSystemLog = GetLogEventLevelFromString(configuration["Serilog:LevelSwitches :$systemLogSwitches"]);


//            var sinkOptions = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true, SchemaName = "dbo" };
//            var coloumnOptions = new ColumnOptions
//            {
//                AdditionalColumns = new Collection<SqlColumn> { new SqlColumn("UserName", SqlDbType.NVarChar) }
//            };
//            logger
//                .WriteTo.MSSqlServer(connectionString, sinkOptions: sinkOptions, restrictedToMinimumLevel: loglevelSystemLog, columnOptions: coloumnOptions);
//        }
//        private static LogEventLevel GetLogEventLevelFromString(string? logLevelEvent)
//        {
//            LogEventLevel logEventLevel;
//            Enum.TryParse(logLevelEvent, true, out logEventLevel);
//            return logEventLevel;
//        }
//    }

//}

