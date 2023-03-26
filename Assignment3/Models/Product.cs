using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Product
    {
        public Product()
        {
            this.Comments = new HashSet<Comment>();
        }
        
        
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        [Column(TypeName = "text")]
        public string? Image { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ShippingCost { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
