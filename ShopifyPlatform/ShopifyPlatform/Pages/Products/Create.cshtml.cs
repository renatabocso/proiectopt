using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopifyPlatform.Models;

namespace ShopifyPlatform.Pages.Products
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
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
