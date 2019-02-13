using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class IndexView
    {
        public DoList DoList { get; set; }
        public List<DoList> DoLists { get; set; }
    }
}