using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnderstandingActionFilters.Filters
{
    public class BeforeActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Date = DateTime.Now;

            base.OnActionExecuting(filterContext);
        }
    }
}