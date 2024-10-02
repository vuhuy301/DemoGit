using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class ProductSize
    {
        public ProductSize()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Psid { get; set; }
        public string? Pid { get; set; }
        public int? Sid { get; set; }
        public int? Quantity { get; set; }

        public virtual Product? PidNavigation { get; set; }
        public virtual Size? SidNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
