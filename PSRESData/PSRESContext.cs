using System;

namespace PSRESData
{
    public class PSRESContext:context
    {
        public DbSet<MeterRecordingEntity> MeterRecordings { get; set; }
        public DbSet<TimeDateEntity> Dates { get; set; }
        public DbSet<MeterEntity> Meters { get; set; }
        public DbSet<SensorRecordingEntity> SensorRecordings { get; set; }
        public DbSet<SensoringStationEntity> SensoringStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server= ENG-PC\SQLEXPRESS; DataBase = PSRESDataTest1; Integrated Security = True; 
                ");
        }
    }
}
