using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopifyPlatform.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        public double Price { get; set; }

        public IList<Order>? Orders { get; set; }
    }
}
