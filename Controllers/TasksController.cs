using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Entity;

namespace TaskManagementSystem.Controllers
{
    public class TasksController : Controller
    {
        private DataContext _context = new DataContext();

        // GET: Tasks
        public ActionResult Index()
        {
            //var tasks = _context.Tasks.Include(t => t.ManagerUser).Include(t => t.WorkerUser);
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
