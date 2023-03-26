using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Comment
    {
       
        public int Id { get; set; }

        public int ProductId { get; set; }
        //public virtual Product Product { get; set; } = null!;

        public string? CommentText { get; set; }
        public string? Rating { get; set; }

        [Column(TypeName = "text")]
        public string? Image { get; set; }
    }
}
