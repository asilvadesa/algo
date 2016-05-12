using System;

namespace Timezone.Models
{
    public class Payment
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string CreditCard { get; set; }
        public DateTime TranDate { get; set; }
    }
}