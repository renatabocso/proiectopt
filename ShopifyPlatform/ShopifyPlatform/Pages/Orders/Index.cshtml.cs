using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopifyPlatform.Models;

namespace ShopifyPlatform.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ShopifyPlatform.Data.ShopifyPlatformEntityContext _context;
        private double _total = 0;

        public IndexModel(ShopifyPlatform.Data.ShopifyPlatformEntityContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;
        public double Total => _total;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                var userName = HttpContext.User.Identity?.Name;
                Customer customer = null;
                if (!string.IsNullOrEmpty(userName))
                {
                    customer = _context.Customer.FirstOrDefault(f => f.Email == userName)!;
                }

                if (customer == null)
                {
                    Order = await _context.Order
                        .Include(o => o.Customer)
                        .Include(o => o.Product)
                        .ToListAsync();
                }
                else
                {
                    Order = await _context.Order
                        .Include(o => o.Customer)
                        .Include(o => o.Product)
                        .Where(o => o.CustomerId == customer.Id)
                        .ToListAsync();
                }

                _total = Order.Sum(s => s.Product?.Price) ?? 0;
            }
        }
    }
}
