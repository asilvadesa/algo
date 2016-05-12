using System.Collections.Generic;
using System.Web;
using Timezone.Models;

namespace Timezone
{
    public class Repo
    {
        IList<Payment> Payments
        {
            get
            {
                if (HttpContext.Current.Session["payments"] == null)
                    HttpContext.Current.Session["payments"] = new List<Payment>();

                return HttpContext.Current.Session["payments"] as List<Payment>;
            }
        }

        public void Add(Payment payment)
        {
            Payments.Add(payment);
        }

        public IList<Payment> GetAll()
        {
            return Payments;
        }
    }
}