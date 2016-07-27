using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evaluation.WebMVC.Models;

namespace Evaluation.WebMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection input)
        {
            using (var ctx = new EmployeeEvaluationEntities())
            {
                var retval = ctx.sp_ValidateLogin(input["username"], input["password"]);
                foreach (var c in retval)
                {
                    if (c.ID>0)
                    {
                        Session["userId"] = c.ID;
                        Session["Username"] = c.Username;
                        return RedirectToAction("Evaluation", "Home");
                    }
                }
            }
            return View();
        }
    }
}