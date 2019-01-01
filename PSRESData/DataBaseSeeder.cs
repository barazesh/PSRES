using System.Linq;
using PSRESData.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;

namespace PSRESData
{
    public class DataBaseSeeder
    {

        private readonly PSRESContext _ctx;
        private readonly UserManager<UserEntity> _userManager;

        public DataBaseSeeder(PSRESContext ctx,
            UserManager<UserEntity> userManager)
        {
            _ctx = ctx;
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
                meters[0] = new MeterEntity()
                {
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