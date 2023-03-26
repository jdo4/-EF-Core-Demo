using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class User
    {
        
        public int Id { get; set; }

        public String Name { get; set; }
       
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ShippingAddress { get; set; }

        public string? PurchaseHistory { get; set; }

    }
}
