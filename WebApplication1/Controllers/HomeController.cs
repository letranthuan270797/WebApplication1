using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Session["user"]==null)
            {
                Response.Redirect("https://localhost:44328/login/index");
            }
            else
            {
                //TVLT_Users user = (TVLT_User)Session["user"];
                //ViewBag.Name = user.FullName;
            }
            return View();
        }

    }
}