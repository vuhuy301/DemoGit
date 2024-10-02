using BilliardShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BilliardShop.Pages.Shop
{
    public class CartModel : PageModel
    {
        private readonly EXEContext _exeContext;

        public CartModel(EXEContext exeContext)
        {
            _exeContext = exeContext;
        }

        public List<ProductSize> CartAo { get; set; } = new List<ProductSize>();

        public List<Product> CartPk { get; set; } = new List<Product>();
        public async Task OnGetAsync()
        {
            var productSizeIds = LoadCartIntFromCookie(Request);

            CartAo = await _exeContext.ProductSizes
        .Where(ps => productSizeIds.Contains(ps.Psid))
        .Include(pm => pm.SidNavigation)
        .Include(ps => ps.PidNavigation) 
        .ThenInclude(p => p.ProductImgs)
        .ToListAsync();

            var productId = LoadCartStringFromCookie(Request);
            CartPk = await _exeContext.Products.Where(p => productId.Contains(p.Pid))
            .Include(ps => ps.ProductImgs).ToListAsync();
        }
        private List<int> LoadCartIntFromCookie(HttpRequest request)
        {
            string cartJson = request.Cookies["biscartint"];
            return string.IsNullOrEmpty(cartJson)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(cartJson);
        }

        private List<string> LoadCartStringFromCookie(HttpRequest request)
        {
            string cartJson = request.Cookies["biscartstring"];
            return string.IsNullOrEmpty(cartJson)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(cartJson);
        }
    }
}
