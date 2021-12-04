using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Entity
{
    public class ManagerUser : User
    {
        [DefaultValue(true)]
        public bool IsManager { get; }
        public List<WorkerUser> WorkerUsers { get; set; }
        public List<Task> Tasks { get; set; }
    }
}