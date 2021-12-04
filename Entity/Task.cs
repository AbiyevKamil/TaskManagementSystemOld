using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Entity
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Title"),
         MinLength(6, ErrorMessage = "Title can't be shorter than 6 characters."),
         MaxLength(30, ErrorMessage = "Title can't be longer than 30 characters.")]
        public string Title { get; set; }
        [Required, DisplayName("Description"),
         MinLength(10, ErrorMessage = "Description can't be shorter than 10 characters.")]
        public string Description { get; set; }
        [Required, DisplayName("Start date")]
        public DateTime StartedDate { get; set; }
        [Required, DisplayName("Deadline")]
        public DateTime DeadLine { get; set; }
        [Required, DefaultValue(false), DisplayName("Is completed")]
        public bool IsCompleted { get; set; }
        [Required, DefaultValue(false), DisplayName("Is public")]
        public bool IsPublic { get; set; }

        public int ManagerUserId { get; set; }
        public virtual ManagerUser ManagerUser { get; set; }
        public int WorkerUserId { get; set; }
        public virtual WorkerUser WorkerUser { get; set; }
    }
}