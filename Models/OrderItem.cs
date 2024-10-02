using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class OrderItem
    {
        public int Otid { get; set; }
        public int? Oid { get; set; }
        public string? Pid { get; set; }
        public int? Quantity { get; set; }
        public int? Psid { get; set; }
        public decimal? Price { get; set; }

        public virtual Order? OidNavigation { get; set; }
        public virtual Product? PidNavigation { get; set; }
        public virtual ProductSize? Ps { get; set; }
    }
}
