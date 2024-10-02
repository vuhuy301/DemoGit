using BilliardShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;
using System.Text.Json;

namespace BilliardShop.Pages.Shop
{
    public class ProductDetailModel : PageModel
    {
        private readonly EXEContext _exeContext;

        public ProductDetailModel(EXEContext exeContext)
        {
            _exeContext = exeContext;
        }
        public Product Product { get; set; }
        public IList<ProductSize> prosize { get; set; }
        public async Task<IActionResult> OnGetAsync(string Pid)
        {
            Product = await _exeContext.Products.Include(p => p.ProductImgs).FirstOrDefaultAsync(p => p.Pid == Pid);
            prosize = await _exeContext.ProductSizes.Where(p => p.Pid == Pid).Include(p => p.SidNavigation).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostProductDetailsAsync(string ProductId, string Size, string type)
        {
            
            
            if(Size == null & type == "aodau")
            {
                TempData["Message"] = "Vui lòng chọn size.";
                return RedirectToPage("/Shop/ProductDetail", new { pId = ProductId });
            }
            if(Size != null & type == "aodau")
            {
                var productSize = await _exeContext.ProductSizes
            .FirstOrDefaultAsync(ps => ps.Pid == ProductId && ps.Sid == Int32.Parse(Size));
                if (productSize == null || productSize.Quantity <= 0)
                {
                    // Nếu không tồn tại hoặc hết hàng, hiển thị thông báo lỗi
                    TempData["Message"] = "Sản phẩm hết hàng.";
                    return RedirectToPage("/Shop/ProductDetail", new { pId = ProductId });
                }

                var cartItems = LoadCartIntFromCookie(Request);
                if (!cartItems.Contains(productSize.Psid))
                {
                    cartItems.Add(productSize.Psid);
                }
                SaveCartIntToCookie(Response, cartItems);
                return RedirectToPage("/Shop/Cart");
            }
            else
            {
                var product = await _exeContext.Products.FirstOrDefaultAsync(p => p.Pid == ProductId);
                if(product == null)
                {
                    TempData["Message"] = "Sản phẩm hết hàng.";
                    return RedirectToPage("/Shop/ProductDetail", new { pId = ProductId });
                }
                var cartItems = LoadCartStringFromCookie(Request);
                if (!cartItems.Contains(ProductId));
                {
                    cartItems.Add(ProductId);
                }
                SaveCartStringToCookie(Response, cartItems);
                return RedirectToPage("/Shop/Cart");
            }

            
        }
        private List<string> LoadCartStringFromCookie(HttpRequest request)
        {
            string cartJson = request.Cookies["biscartstring"];
            return string.IsNullOrEmpty(cartJson)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(cartJson);
        }
        private List<int> LoadCartIntFromCookie(HttpRequest request)
        {
            string cartJson = request.Cookies["biscartint"];
            return string.IsNullOrEmpty(cartJson)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(cartJson);
        }

        private void SaveCartStringToCookie(HttpResponse response, List<string> cartItems)
        {
            var cartJson = JsonSerializer.Serialize(cartItems);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            response.Cookies.Append("biscartstring", cartJson, options);
        }
        private void SaveCartIntToCookie(HttpResponse response, List<int> cartItems)
        {
            var cartJson = JsonSerializer.Serialize(cartItems);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            response.Cookies.Append("biscartint", cartJson, options);
        }
    }
}
