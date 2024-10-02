using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Rid { get; set; }
        public string? Rname { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
