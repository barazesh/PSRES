using Microsoft.AspNetCore.Mvc;
using PSRES.Data;
using PSRES.Web.ViewModels;
using PSRESLogic;
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
            ViewMeter meter = new ViewMeter();
            meter.Meters = meters.ToList();
                         
            return View(meter);
        }

        [HttpPost("data/meters")]
        public IActionResult Meters(ViewMeter model)
        {

            var recording = from r in _context.MeterRecordings where r.MeterId == model.Value select r;



            return View("MeterData", recording.Last());
        }


        public IActionResult MeterData()
        {
            return View();
        }



    }
}
