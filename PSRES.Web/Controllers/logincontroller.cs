using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.Controllers
{
    public class logincontroller: Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
