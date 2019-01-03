using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.Controllers
{
    public class AccountController:Controller
    {
        //private readonly Logger<AccountController> logger;

        //public AccountController(Logger<AccountController> logger)
        //{
        //    this.logger = logger;
        //}

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
    }
}
