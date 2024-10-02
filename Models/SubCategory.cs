using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Scid { get; set; }
        public string? Scname { get; set; }
        public int? Cid { get; set; }

        public virtual Category? CidNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
