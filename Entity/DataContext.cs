using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("TasksDB")
        {

        }

        public DbSet<Task> Tasks { get; set; }
        //public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<WorkerUser> WorkerUsers { get; set; }
        public DbSet<ManagerUser> ManagerUsers { get; set; }
    }
}