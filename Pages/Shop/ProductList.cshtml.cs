using BilliardShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BilliardShop.Pages.Shop
{
    public class ProductListModel : PageModel
    {
        private readonly EXEContext _exeContext;
        public int cid;
        public ProductListModel(EXEContext exeContext)
        {
            _exeContext = exeContext;
        }
        public IList<Product> Products { get; private set; }
        public async Task OnGetAsync(int category, string sort)
        {
            cid = category;
            var query = _exeContext.Products.AsQueryable();
            if (category > 0)
            {
                query = query.Include(p => p.ProductImgs).Where(p => p.Cid == category);
            }
            else
            {
                query = query.Include(p => p.ProductImgs);
            }

            if (sort == "price-asc")
            {
                Products = await query.OrderBy(p => p.Price).ToListAsync();
            }
            else if (sort == "price-desc")
            {
                Products = await query.OrderByDescending(p => p.Price).ToListAsync();
            }
            else if (sort == "name-asc")
            {
                Products = await query.OrderBy(p => p.Pname).ToListAsync();
            }
            else if (sort == "mane-desc")
            {
                Products = await query.OrderByDescending(p => p.Pname).ToListAsync();
            }
            else
            {
                Products = await query.ToListAsync();
            }
        }
    }
}
