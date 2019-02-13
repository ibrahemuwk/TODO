using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class DoList
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsCompleted { get; set; }
        public string Status { get; set; }
    }
}