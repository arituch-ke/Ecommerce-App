using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Entites
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal OriginalPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountedPrice { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }
        public required string Category { get; set; }
        public required string Vendor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<SKU>? SKUs { get; set; }
    }
}
