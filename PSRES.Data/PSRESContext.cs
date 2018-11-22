using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using PSRES.Data.Entities;

namespace PSRES.Data
{
    public class PSRESContext:DbContext
    {
        public static readonly LoggerFactory myConsoleLoggerFactory = new LoggerFactory(new[]
        {
            new ConsoleLoggerProvider((category, level)=> category ==DbLoggerCategory.Database.Command.Name
            && level== LogLevel.Information,true)
        });


        public DbSet<MeterRecordingEntity> MeterRecordings { get; set; }
        public DbSet<TimeDateEntity> Dates { get; set; }
        public DbSet<MeterEntity> Meters { get; set; }
        public DbSet<SensorRecordingEntity> SensorRecordings { get; set; }
        public DbSet<SensoringStationEntity> SensoringStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(myConsoleLoggerFactory)
                .UseSqlServer(@"Server= ENG-PC\SQLEXPRESS; DataBase = PSRESDataTest1; Integrated Security = True; 
                ");
        }


    }
}
 