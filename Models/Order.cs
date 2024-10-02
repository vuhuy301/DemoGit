using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Oid { get; set; }
        public int? Uid { get; set; }
        public decimal? Totalamount { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Notes { get; set; }
        public DateTime? Orderdate { get; set; }
        public int? Pmid { get; set; }

        public virtual PaymentMethod? Pm { get; set; }
        public virtual User? UidNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
