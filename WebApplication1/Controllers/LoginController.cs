using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //
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
            if (uid == "admin" && pwd == "123456")
            {
                Session["user"] = "admin";
                Session.Timeout = 5;
                
                var acountid = ConfigurationManager.AppSettings["SMSAccountIdentification"];
                var authToken = ConfigurationManager.AppSettings["SMSAccountPassword"];
                TwilioClient.Init(acountid, authToken);
                var to = new PhoneNumber("+84384443542");
                var from = new PhoneNumber("+14094985275");
                string otp =string.Empty;
                Random rd = new Random();
                for(int i = 0;i<5; i++)
                {
                    int temp = rd.Next(0, 10);
                    otp += temp;
                }
                var mess = MessageResource.Create(
                        to: to,
                        from: from,
                        body: otp
                    );
                jr.Data = new
                {
                    status = "OK",
                    res = otp
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
        [HttpGet]
        public ActionResult GetOtp(string resOtp)
        {
            OtpModel model = new OtpModel
            {
                otpkey = resOtp
            };
            return PartialView("~/views/Login/OtpInput.cshtml", model);
        }
        [HttpPost]
        public ActionResult GetOtp(OtpModel model)
        {
            if (model.otpkey.Equals(model.otpText))
            {
                Response.Redirect("https://localhost:44328/home/index");

            }

            ViewBag.mess = "Mã xác thực không hợp lệ";
            return PartialView("~/views/Login/OtpInput.cshtml", model);
        }


    }
}