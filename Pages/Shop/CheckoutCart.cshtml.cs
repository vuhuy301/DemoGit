using BilliardShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BilliardShop.Pages.Shop
{
    public class CheckoutCartModel : PageModel
    {
        private readonly EXEContext _exeContext;

        public List<ProductCheckoutModel> CartProducts { get; set; }
        public List<ProductPkCheckoutModel> CartPk { get; set; }
        public decimal ? CartTotal { get; set; } = 0;
		[BindProperty]
		public string name { get; set; }

		[BindProperty]
		public string phone { get; set; }

		[BindProperty]
		public string address { get; set; }

		[BindProperty]
		public string city { get; set; }

		[BindProperty]
		public string district { get; set; }

		[BindProperty]
		public string ward { get; set; }

		[BindProperty]
		public int payment { get; set; }

		[BindProperty]
		public string note { get; set; }
		[BindProperty]
		public decimal totalamount { get; set; }
		[BindProperty]
		public List<string> Pid { get; set; }
		[BindProperty]
		public List<int> PsIds { get; set; }
		[BindProperty]
		public List<decimal> price { get; set; }
		[BindProperty]
		public List<int> soluong { get; set; }
		public CheckoutCartModel(EXEContext exeContext)
        {
            _exeContext = exeContext;
        }

        public async Task<IActionResult> OnGetAsync(List<string> PIds, List<int> Quantitie, List<int> PsIds)
        {
            int count = 0;
            CartProducts = new List<ProductCheckoutModel>();
            for (int i = 0; i < PsIds.Count; i++)
            {
                count = i;
                var productSize = await _exeContext.ProductSizes
                 .Include(p => p.PidNavigation)
                 .Include(m => m.SidNavigation)
                 .FirstOrDefaultAsync(ps => ps.Psid == PsIds[i]);

                if (productSize != null)
                {
                    CartProducts.Add(new ProductCheckoutModel
                    {
                        Product = productSize,
                        Quantity = Quantitie[i]
                    });
                }
                CartTotal = CartTotal + productSize.PidNavigation.Price * Quantitie[i] * (100 - productSize.PidNavigation.Sale) / 100;
            }

            CartPk = new List<ProductPkCheckoutModel>();
            for (int i = 0; i < PIds.Count; i++)
            {
                count++;
                var product = await _exeContext.Products
                 .FirstOrDefaultAsync(ps => ps.Pid == PIds[i]);

                if (product != null)
                {
                    CartPk.Add(new ProductPkCheckoutModel
                    {
                        Product = product,
                        Quantity = Quantitie[count]
                    });
                }
                CartTotal = CartTotal + product.Price * Quantitie[count] * (100 - product.Sale) / 100;
            }

            return Page();
        }
		public async Task<IActionResult> OnPostAsync()
		{
			int c = 0;
			var order = new Order
			{
				Name = name,
				Phone = phone,
				Address = address + "," + ward + "," + city + "," + district,
				Notes = note,
				Orderdate = DateTime.Now,
				Totalamount = totalamount,
				Pmid = 1,
				Status = "Chờ xác nhận"
			};
			/*if (HttpContext.Session.GetInt32("UserId") != null)
			{
				order.Uid = HttpContext.Session.GetInt32("UserId");
			}*/
			_exeContext.Orders.Add(order);
			_exeContext.SaveChanges();
			for (int i = 0; i < PsIds.Count; i++)
			{
				c = i;
				var orderItem = new OrderItem
				{
					Oid = order.Oid,
					Psid = PsIds[i],
					Quantity = soluong[i],
					Price = price[i]
				};
				_exeContext.OrderItems.Add(orderItem);
				_exeContext.SaveChanges();
			}
			for (int i = 0; i < Pid.Count; i++)
			{
				c++;
				var orderItem = new OrderItem
				{
					Oid = order.Oid,
					Pid = Pid[i],
					Quantity = soluong[c],
					Price = price[c]
				};
				_exeContext.OrderItems.Add(orderItem);
				_exeContext.SaveChanges();
			}
			return RedirectToPage("/Shop/Thankyou");
		}

		public class ProductCheckoutModel
        {
            public ProductSize Product { get; set; }
            public int Quantity { get; set; }
        }

        public class ProductPkCheckoutModel
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }
    }

}
