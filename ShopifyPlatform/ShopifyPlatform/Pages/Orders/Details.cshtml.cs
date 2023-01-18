using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopifyPlatform.Models;

namespace ShopifyPlatform.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly ShopifyPlatform.Data.ShopifyPlatformEntityContext _context;

        public DetailsModel(ShopifyPlatform.Data.ShopifyPlatformEntityContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.Include(i => i.Customer).Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }
    }
}
