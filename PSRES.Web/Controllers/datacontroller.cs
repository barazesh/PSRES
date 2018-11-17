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

        public IActionResult Meters()
        {
            ViewBag.Title = "Energy Consumption Monitoring";

            return View();
        }


    }
}
