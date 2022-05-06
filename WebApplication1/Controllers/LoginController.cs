using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                Response.Redirect("https://localhost:44328/home/index");
            }
            return View();
        }
        /// <summary>
        /// Kiem tra dang nhap bang Json
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public JsonResult CheckLogin(FormCollection collection)
        {
            string uid = collection["uid"];
            string pwd = collection["pass"];
            JsonResult jr = new JsonResult();
            //DBIO db = new DBIO();
            //TVLT_User u = db.GetOBject_UserbyUsername(uid);
            //if (u != null)
            //{
            //    jr.Data = new
            //    {
            //        status = "F"
            //    };
            //}
            //else
            //{
            //    if (u.Pwd == pwd)
            //    {
            //        Session["user"] = u;
            //        Session.Timeout = 5;
            //        jr.Data = new
            //        {
            //            status = "OK"
            //        };
            //    }
            //    else
            //    {
            //        jr.Data = new
            //        {
            //            status = "F"
            //        };

            //    }
            //}
            if (uid == "admin"  && pwd == "123465")
            {
                Session["user"] = "admin";
                Session.Timeout = 5;
                jr.Data = new
                {
                    status = "OK"
                };
            }
            else
            {
                jr.Data = new
                {
                    status = "F"
                };
                
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
    }
}