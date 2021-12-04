using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Entity
{
    public class WorkerUser : User
    {
        [DefaultValue(false)]
        public bool IsManager { get; }
        public List<Task> Tasks { get; set; }
    }
}