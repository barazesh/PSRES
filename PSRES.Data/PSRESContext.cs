using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRESLogic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace PSRES.Data
{
    public class PSRESContext:DbContext
    {
        public static readonly LoggerFactory myConsoleLoggerFactory = new LoggerFactory(new[]
        {
            new ConsoleLoggerProvider((category, level)=> category ==DbLoggerCategory.Database.Command.Name
            && level== LogLevel.Information,true)
        });


        public DbSet<MeterRecording> MeterRecordings { get; set; }
        public DbSet<TimeDate> Dates { get; set; }
        public DbSet<Meter> Meters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(myConsoleLoggerFactory)
                .UseSqlServer(@"Server= ENG-PC\SQLEXPRESS; DataBase = PSRESDataTest1; Integrated Security = True; 
                ");
        }


    }
}
 