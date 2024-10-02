using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Uid { get; set; }
        public string? Uname { get; set; }
        public string? Upass { get; set; }
        public int? Rid { get; set; }
        public bool? Status { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual Role? RidNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
