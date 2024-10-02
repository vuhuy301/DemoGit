using BilliardShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BilliardShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EXEContext _context;

        public IndexModel(ILogger<IndexModel> logger, EXEContext context)
        {
            _logger = logger;
            _context = context;
        }
		public List<Product> Products { get; set; }
		public void OnGet()
        {
            Products = _context.Products
			   .Where(p => p.Cid == 1)
			   .Include(p => p.ProductImgs)
			   .OrderByDescending(p => p.Datecreate)
			   .Take(3)
			   .ToList();
		}
    }
}