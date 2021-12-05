using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Entity;

namespace TaskManagementSystem.Controllers
{
    public class ManagerController : Controller
    {
        private DataContext _context = new DataContext();
        public ActionResult Dashboard()
        {
            var token = Session["AuthToken"];
            if (token != null)
            {
                int id = Convert.ToInt32(token.ToString());
                var user = _context.ManagerUsers.Include(i => i.WorkerUsers).Include(i => i.Tasks)
                    .FirstOrDefault(i => i.Id == id);
                return View(user);
            }
            return RedirectToAction("Login", "Account", new
            {
                returnUrl = "Dashboard"
            });
        }
    }
}