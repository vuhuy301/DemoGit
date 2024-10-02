using BilliardShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BilliardShop.Pages.Shop
{
    public class CheckoutModel : PageModel
    {
		private readonly EXEContext _exeContext;
        public ProductSize ProductSize { get; set; }

        public Product Product { get; set; }
        public IList<ProductSize> prosize { get; set; }
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
		public string Psid { get; set; }
		[BindProperty]
		public string Pid { get; set; }
		public CheckoutModel(EXEContext exeContext)
		{
			_exeContext = exeContext;
		}

        public async Task<IActionResult> OnGetAsync(string ProductId, string Size, string type)
        {

           if(type == "aodau")
           {
                if (!int.TryParse(Size, out int sizeId))
                {
                    TempData["Message"] = "Vui lòng chọn size.";
                    return RedirectToPage("/Shop/ProductDetail", new { pId = ProductId });
                }

                var productSize = await _exeContext.ProductSizes
                    .Include(p => p.PidNavigation)
                    .Include(m => m.SidNavigation)
                    .FirstOrDefaultAsync(ps => ps.Pid == ProductId && ps.Sid == sizeId);

                ProductSize = productSize;
                
           }
           if(type == "phukien")
            {
                var product = await _exeContext.Products.Include(m => m.ProductImgs).FirstOrDefaultAsync(p => p.Pid == ProductId);
                Product = product;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string ProductId, string Size)
        {
           
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
			    if(Size != null)
			{
				var orderItem = new OrderItem
				{
					Oid = order.Oid,
					Psid = Int32.Parse(Psid),
					Quantity = 1,
					Price = totalamount
				};
				_exeContext.OrderItems.Add(orderItem);
				_exeContext.SaveChanges();
			}
			else
			{
				var orderItem = new OrderItem
				{
					Oid = order.Oid,
					Pid = Pid,
					Quantity = 1,
					Price = totalamount
				};
				_exeContext.OrderItems.Add(orderItem);
				_exeContext.SaveChanges();
			}
				
				
	
			return RedirectToPage("/Shop/Thankyou");
		}

    }
}
