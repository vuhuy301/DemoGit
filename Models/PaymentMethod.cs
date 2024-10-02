using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int Pmid { get; set; }
        public string? Pmname { get; set; }
        public bool? Status { get; set; }
        public string? Pmdes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
