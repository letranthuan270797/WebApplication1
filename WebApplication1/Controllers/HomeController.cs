using DatabasaProvider;
using DatabaseIO;
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

            //if (Session["user"]==null)
            //{
            //    Response.Redirect("https://localhost:44328/login/index");
            //}
            //else
            //{
            //    //TVLT_Users user = (TVLT_User)Session["user"];
            //    //ViewBag.Name = user.FullName;
            //}


            //DBIO db = new DBIO();
            //kymdan_Users u = db.GetObject_User("admin", "admin");            
            //return View(u);

            DBIO db = new DBIO();
            List<kymdan_Users> list = db.GetList_User();
            return View(list);

        }
        /// <summary>
        /// Them User moi
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUser(FormCollection data)
        {
            string uid = data["uid"];
            string pwd = data["pwd"];
            string name = data["name"];
            JsonResult js = new JsonResult();
            if (string.IsNullOrEmpty(uid) ||
                string.IsNullOrEmpty(pwd) ||
                string.IsNullOrEmpty(name))
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Khong the bo trong du lieu"
                };
            }
            else
            {
                DBIO db = new DBIO();
                kymdan_Users u = new kymdan_Users();
                u.ID = Guid.NewGuid().ToString();               
                u.Uid = uid;
                u.Pwd = pwd;
                u.Fullname = name;

                db.AddObject(u);
                db.Save();
                js.Data = new
                {
                    NewID = u.ID,
                    status = "OK"

                };               
            }
            return Json(js, JsonRequestBehavior.AllowGet);            
        }
        /// <summary>
        /// Xoa 1 ROW
        /// </summary>      
        [HttpPost]
        public JsonResult DeleteUser(FormCollection data)
        {
            string id = data["id"];
            
            JsonResult js = new JsonResult();
            if (string.IsNullOrEmpty(id) )
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Khong the bo trong du lieu"
                };
            }
            else
            {
                DBIO db = new DBIO();

                kymdan_Users u = db.GetObject_User(id);
                if (u== null)
                {
                    js.Data = new
                    {
                        status = "ERROR",
                        message = "Du lieu khong ton tai"
                    };
                }
                else
                {
                    db.DeleteObject(u);
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
               

               
                
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cap nhat 1 ROW - EDIT ROW
        /// </summary>        
        [HttpPost]
        public JsonResult EditUser(FormCollection data)
        {
            string id = data["id"];
            string uid = data["uid"];
            string pwd = data["pwd"];
            string name = data["name"];
            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id)||
                string.IsNullOrEmpty(uid)||
                string.IsNullOrEmpty(name)
                )
            {
                js.Data = new
                {
                    status = "ERROR",
                    message = "Khong the bo trong du lieu(tru password)"
                };
            }
            else
            {
                DBIO db = new DBIO();

                kymdan_Users u = db.GetObject_User(id);
                if (u == null)
                {
                    js.Data = new
                    {
                        status = "ERROR",
                        message = "Du lieu khong ton tai"
                    };
                }
                else
                {
                    u.Uid = uid;
                    u.Fullname = name;
                    if (!string.IsNullOrEmpty(pwd))
                    {
                        u.Pwd = pwd;
                    }
                    db.Save();
                    js.Data = new
                    {
                        status = "OK"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}