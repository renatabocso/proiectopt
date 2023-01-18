using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopifyPlatform.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
