using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            ProductImgs = new HashSet<ProductImg>();
            ProductSizes = new HashSet<ProductSize>();
        }

        public string Pid { get; set; } = null!;
        public string? Pname { get; set; }
        public string? Pdes { get; set; }
        public decimal? Price { get; set; }
        public int? Cid { get; set; }
        public bool? Status { get; set; }
        public int? Scid { get; set; }
		public int? Sale { get; set; }

		public DateTime? Datecreate { get; set; }
        public decimal? Capitalprice { get; set; }

        public virtual Category? CidNavigation { get; set; }
        public virtual SubCategory? Sc { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductImg> ProductImgs { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
