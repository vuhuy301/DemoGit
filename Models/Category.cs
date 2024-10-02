using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            SubCategories = new HashSet<SubCategory>();
        }

        public int Cid { get; set; }
        public string? Cname { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
