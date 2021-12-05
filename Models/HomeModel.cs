using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagementSystem.Entity;

namespace TaskManagementSystem.Models
{
    public class HomeModel
    {
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<WorkerUser> Workers { get; set; }
        public IEnumerable<ManagerUser> Managers { get; set; }
    }
}