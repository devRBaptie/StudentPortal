using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _17599075_PROG_POE.Models;

namespace _17599075_PROG_POE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(_17599075_PROG_POE.Models.STUDENT stuModel)
        {
            using (Db_Entities db = new Db_Entities())
            {
                try
                {
                    var userDetails = db.STUDENTS.Where(x => x.USERNAME == stuModel.USERNAME && x.PASSWORD == stuModel.PASSWORD).FirstOrDefault();

                    if (userDetails == null)
                    {
                        //stuMdbodel.LoginErrorMessage = "Wrong username or password";

                        return View("Index",stuModel);
                    }
                    else
                    {
                        Session["userName"] = userDetails.USERNAME;
                        Session["firstName"] = userDetails.FIRSTNAME;
                        Session["surname"] = userDetails.SURNAME;
                        Session["mark"] = userDetails.TEST_MARK;

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}