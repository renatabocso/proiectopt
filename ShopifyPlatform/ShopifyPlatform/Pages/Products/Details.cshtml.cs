using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopifyPlatform.Models;

namespace ShopifyPlatform.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ShopifyPlatform.Data.ShopifyPlatformEntityContext _context;

        public DetailsModel(ShopifyPlatform.Data.ShopifyPlatformEntityContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}
