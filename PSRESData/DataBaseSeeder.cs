using System.Linq;
using PSRESData.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;





namespace PSRESData
{
    public class DataBaseSeeder
    {

        private readonly PSRESContext _ctx;
        private readonly IHostingEnvironment hosting;
        private readonly UserManager<UserEntity> _userManager;

        public DataBaseSeeder(PSRESContext ctx,
            IHostingEnvironment hosting,
            UserManager<UserEntity> userManager)
        {
            _ctx = ctx;
            this.hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByNameAsync("Admin");

            if (user== null)
            {
                user = new UserEntity()
                {
                    UserName = "Admin"
                };

                var result = await _userManager.CreateAsync(user,"P@ssw0rd!");
                if (result!=IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create the admin user");
                }
            }

            if (!_ctx.Meters.Any())
            {
                MeterEntity[] meters = new MeterEntity[5];
                var metersfilepath = Path.Combine(hosting.ContentRootPath, @"Services\metersentity.json");
                meters = JsonConvert.DeserializeObject<MeterEntity[]>(File.ReadAllText(metersfilepath));


                _ctx.Meters.AddRange(meters);
                _ctx.SaveChanges();


            }
        }
    }
}