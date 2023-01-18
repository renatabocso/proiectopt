using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopifyPlatform.Models;

namespace ShopifyPlatform.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ShopifyPlatform.Data.ShopifyPlatformEntityContext _context;

        public CreateModel(ShopifyPlatform.Data.ShopifyPlatformEntityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var userName = HttpContext.User.Identity?.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var customer = _context.Customer.FirstOrDefault(f => f.Email == userName);
                if (customer != null)
                {
                    Order = new Order { Customer = customer, CustomerId = customer.Id };
                }
            }

            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "FullName");
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userName = HttpContext.User.Identity?.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var customer = _context.Customer.FirstOrDefault(f => f.Email == userName);
                if (customer != null)
                {
                    Order.Customer = customer;
                    Order.CustomerId = customer.Id;
                }
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
