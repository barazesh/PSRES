using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.Controllers
{
    public class datacontroller: Controller
    {
       

        public IActionResult Sensors()
        {
            return View();
        }

        //[HttpGet("meters")]
        public IActionResult Meters()
        {
            return View();
        }

        [HttpPost("data/meters")]
        public IActionResult Meters(object model)
        {
            return View();
        }




    }
}
