using System;
using System.Linq;
using System.Web.Mvc;
using Timezone.Models;

namespace Timezone.Controllers
{
    /// <summary>
    /// Base for all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Read the timezone offset value from cookie and store in session.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Request.Cookies.AllKeys.Contains("timezoneoffset"))
            {
                Session["timezoneoffset"] = HttpContext.Request.Cookies["timezoneoffset"].Value;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class HomeController : BaseController
    {
        Repo repo = new Repo();

        public ActionResult Index()
        {
            var payments = repo.GetAll();
            return View(payments);
        }

        public ActionResult MakePayment(Payment payment)
        {
            payment.TranDate = DateTime.UtcNow;
            repo.Add(payment);
            return RedirectToAction("Index");
        }
    }
}
