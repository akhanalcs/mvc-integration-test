using System.ComponentModel.DataAnnotations;

namespace MyCoolApp.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        // Other props that I don't care about at this time.
        public decimal OrderTotal { get; set; }
    }
}
