using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Order
    {
        
        public int Id { get; set; }


        public int ProductId { get; set; }

        public virtual Product? Product { get; set; } = null!;



        public int UserID { get; set; }
       

        public int? Status { get; set; }
        public string? BillNo { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
