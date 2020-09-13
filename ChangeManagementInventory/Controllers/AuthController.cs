using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Controllers
{
    // /Auth
    public class AuthController : Controller
    {
        // /Auth/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}