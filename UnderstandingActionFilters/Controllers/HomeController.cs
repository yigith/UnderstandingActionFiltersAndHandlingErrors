using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnderstandingActionFilters.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HandleError]
        public ActionResult ActionWithError()
        {
            decimal value = 0;
            value /= value;
            return null;
        }
        public ActionResult ActionWithFormatException()
        {
            int num = Convert.ToInt32("I am not a number");
            return null;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // let's catch a specific kind of error
            if (filterContext.Exception is FormatException)
            {
                filterContext.ExceptionHandled = true; // let me handle this (talking to HandleError attribute)
                filterContext.Result = Content("<h1>What have you done???</h1>");
            }
        }
    }
}