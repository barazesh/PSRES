using Microsoft.AspNetCore.Mvc;
using PSRES.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.Controllers
{
    public class datacontroller: Controller
    {
        private readonly PSRESContext _context;

        public datacontroller(PSRESContext context)
        {
            _context = context;
        }

        public IActionResult Sensors()
        {
            return View();
        }

        public IActionResult Meters()
        {
            var meters = from m in _context.Meters orderby m.Serialcode select m;
                         
            return View(meters.ToList());
        }

        [HttpPost("data/meters")]
        public IActionResult Meters(object model)
        {
            var recording = _context.MeterRecordings.Last();

            return View("MeterData", recording);
        }


        public IActionResult MeterData()
        {
            return View();
        }



    }
}
