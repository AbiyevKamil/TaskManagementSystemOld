using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Entity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context = new DataContext();
        public ActionResult Index()
        {
            var tasks = _context.Tasks.Include(i => i.ManagerUser).Include(i => i.WorkerUser).Where(i => i.IsPublic);
            var workers = _context.WorkerUsers.Include(i => i.Tasks).Where(i => !i.IsManager);
            var managers = _context.ManagerUsers.Include(i => i.Tasks).Where(i => i.IsManager);
            var data = new HomeModel()
            {
                Managers = managers.ToList(),
                Workers = workers.ToList(),
                Tasks = tasks.ToList(),
            };
            return View(data);
        }
    }
}