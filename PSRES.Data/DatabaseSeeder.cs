using PSRES.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PSRES.Data
{
    public class DatabaseSeeder
    {
        private readonly PSRESContext _ctx;

        public DatabaseSeeder(PSRESContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Meters.Any())
            {
                MeterEntity[] meters = new MeterEntity[5];
                meters[0] = new MeterEntity() {
                    Name = "mainroom HVAC",
                    Serialcode = 18119713646205
                 };

                meters[1] = new MeterEntity()
                {
                    Name = "mainroom other",
                    Serialcode = 18119713646206
                };

                meters[2] = new MeterEntity()
                {
                    Name = "smallroom HVAC",
                    Serialcode = 18119713646207
                };

                meters[3] = new MeterEntity()
                {
                    Name = "smallroom other",
                    Serialcode = 18119713646209
                };

                meters[4] = new MeterEntity()
                {
                    Name = "lighting",
                    Serialcode = 18119713646208
                };

                _ctx.Meters.AddRange(meters);
                _ctx.SaveChanges();


            }
        }
    }
}
