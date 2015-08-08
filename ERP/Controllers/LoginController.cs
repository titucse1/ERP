using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ERP.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        private ERPEntities db = new ERPEntities();

        public ActionResult Index()
        {

            if (Session["sess_USER_NO"] != null)
            {
                Response.Redirect("~/home");
               
            }
            else
            {
                return View();
            }
            return View();
            
        }

        [HttpPost]
        public ActionResult Index(SEC_USER sec_user)
        {
            SEC_USER_LOGIN_Result user = db.SEC_USER_LOGIN(sec_user.USER_NAME, sec_user.USER_PWD, 1).FirstOrDefault();
            //SEC_USER(sec_user.USER_NAME, sec_user.USER_PWD, null).FirstOrDefault();
            if (user != null && user.USER_NO > 0)
            {
                
                string sess_id = Session.SessionID;
                string ip_addr = Request.ServerVariables["REMOTE_ADDR"];
                // string device_id =    CustomValidator.GetDeviceId();


                SEC_USER_LOGONS_INSERT_Result LOGON_NO = db.SEC_USER_LOGONS_INSERT(user.USER_NO, ip_addr, null, null, null, null, sess_id, null, null).First();

                Session["sess_sec_users"] = user;
                Session["sess_USER_NO"] = user.USER_NO;
                Session["sess_USER_NAME"] = user.USER_NAME;
                Session["sess_LOGON_NO"] = LOGON_NO;

                Response.Redirect("~/home");

            }

            return View();
        }


        public ActionResult Logout()
        {

            Session.Abandon();
            Response.Redirect("~/login");
            return View();

        }


        public ActionResult Home()
        {
            decimal USER_NO = decimal.Parse(Session["sess_USER_NO"].ToString());

            //decimal? expense_approve_count = db.TRN_EXPENSE_APPROVAL_COUNT(USER_NO).FirstOrDefault();
            //ViewBag.expense_approve_count = expense_approve_count;


            return View();
        }

    }
}
