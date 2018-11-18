using PSRESLogic;
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
                Meter[] meters = new Meter[5];
                meters[0].Name = "mainroom HVAC";
                meters[0].Serialcode = 18119713646205;

                meters[0].Name = "mainroom other";
                meters[0].Serialcode = 18119713646206;

                meters[0].Name = "smallroom HVAC";
                meters[0].Serialcode = 18119713646207;

                meters[0].Name = "smallroom other";
                meters[0].Serialcode = 18119713646209;

                meters[0].Name = "lighting";
                meters[0].Serialcode = 18119713646208;

                _ctx.Meters.AddRange(meters);
                _ctx.SaveChanges();


            }
        }
    }
}
