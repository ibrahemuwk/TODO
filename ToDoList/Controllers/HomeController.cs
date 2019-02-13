using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       // /// <summary>
       // /// Application DB context
       // /// </summary>
       //  ApplicationDbContext ApplicationDbContext { get; set; }

       // /// <summary>
       // /// User manager - attached to application DB context
       // /// </summary>
       //  UserManager<ApplicationUser> UserManager { get; set; }

       //public HomeController()
       // {
       //     this.ApplicationDbContext = new ApplicationDbContext();
       //     this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
       // }
       [Authorize]
        public ActionResult Index()
        {
            IndexView indexView =new IndexView();
            //ApplicationUser UserManager = new ApplicationUser();
            //var context = new IdentityDbContext();
            //var users = context.Users.Where(e => e.Id==);
            List<DoList> listDoLists = new List<DoList>();
            if (Request.IsAuthenticated)
            {
                var userId= User.Identity.GetUserId();
                
                listDoLists = _context.DoLists.Where(l => l.UserId == userId).ToList();

            }

            indexView.DoLists = listDoLists;

            return View(indexView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(IndexView indexView)
        {
            var doList = indexView.DoList;
            if (!doList.Description.IsNullOrWhiteSpace())
            {
                doList.Time = DateTime.Now;
                doList.UserId = User.Identity.GetUserId();

                _context.DoLists.Add(doList);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
           

        }
       
        public JsonResult IsComplete(bool chk, string id)
        {
            int itemId = Int32.Parse(id);
            _context.DoLists.SingleOrDefault(m => m.Id == itemId).IsCompleted = chk;
            _context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult delete_list(string id)
        {
            int itemId = Int32.Parse(id);
            var item=_context.DoLists.Find(itemId);
            _context.DoLists.Remove(item);
            //_context.DoLists.SingleOrDefault(m => m.Id == itemId).IsCompleted = chk;
            _context.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}