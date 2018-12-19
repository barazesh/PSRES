using Microsoft.AspNetCore.Mvc;
using PSRESData;
using PSRES.Web.ViewModels;
using PSRESLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRES.Web.Services;

namespace PSRES.Web.Controllers
{
    public class datacontroller : Controller
    {
        private readonly PSRESContext _context;
        private readonly IController systemControl;

        public datacontroller(PSRESContext context, IController SystemControl)
        {
            _context = context;
            systemControl = SystemControl;
        }

        public IActionResult Sensors()
        {
            return View();
        }

        public IActionResult Meters()
        {

            return View(systemControl.GetrealTimeMetersData());
        }


        public IActionResult LampControl()
        {
            return View();
        }


        [HttpPost("data/LampControl")]
        public IActionResult LampControl(LampViewModel model)
        {
            switch (model.All)
            {
                case true:
                    switch (model.controltype)
                    {
                        case "Frequency":
                            systemControl.ChangeFrequency(model.Frequency);
                            break;
                        case "Dim":
                            systemControl.Dim(model.DutyCycle);
                            break;
                    }
                    break;
                case false:
                    switch (model.controltype)
                    {
                        case "Frequency":
                            systemControl.ChangeFrequency(model.Index, model.Frequency);
                            break;
                        case "Dim":
                            systemControl.Dim(model.Index, model.DutyCycle);
                            break;
                    }
                    break;
            }

            return View();
        }






    }
}
