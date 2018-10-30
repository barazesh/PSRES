using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRESLogic;


namespace PSRES.Data
{
    public class PSRESContext:DbContext
    {
        public DbSet<MeterRecording> MeterRecordings { get; set; }
        public DbSet<TimeDate> Dates { get; set; }
        public DbSet<Meter> Meters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database=PSRESDataTest; Trusted_Connection = True;");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
 