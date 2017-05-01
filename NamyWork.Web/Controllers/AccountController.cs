using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamyWork.Web.Controllers
{
    public class AccountController : WebController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}