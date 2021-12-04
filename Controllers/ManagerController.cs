using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagementSystem.Controllers
{
    public class ManagerController : Controller
    {
        //[Authorize]
        public ActionResult Dashboard()
        {
            var token = Session["AuthToken"];
            if (token != null)
            {
                int id = Convert.ToInt32(token.ToString());
                //var user = _context
            }
            return RedirectToAction("Login", "Account", new
            {
                returnUrl = "Dashboard"
            });
        }
    }
}