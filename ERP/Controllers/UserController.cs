using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            if (Session["sess_USER_NO"] == null)
            {
                Response.Redirect("~/login");

            }
            else
                return View(); 
            
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

    }
}
