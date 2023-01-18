using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopifyPlatform.Data;
using ShopifyPlatform.Models;

namespace ShopifyPlatform.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ShopifyPlatform.Data.ShopifyPlatformEntityContext _context;

        public IndexModel(ShopifyPlatform.Data.ShopifyPlatformEntityContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userName = HttpContext.User.Identity?.Name;
            Customer customer = null;
            if (!string.IsNullOrEmpty(userName))
            {
                customer = _context.Customer.FirstOrDefault(f => f.Email == userName)!;
            }

            if (_context.Customer != null)
            {
                if (customer == null)
                {
                    Customer = await _context.Customer.ToListAsync();
                }
                else
                {
                    Customer = await _context.Customer.Where(c => c.Email == customer.Email).ToListAsync();
                }
            }
        }
    }
}
