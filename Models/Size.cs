using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public int Sid { get; set; }
        public string? Sname { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
