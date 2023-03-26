using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Cart
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; } = null!;
        public int UserID { get; set; }
        public int Quantity { get; set; }
    }
}
