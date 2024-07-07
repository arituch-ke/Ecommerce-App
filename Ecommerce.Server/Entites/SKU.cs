using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Entites
{
    public class SKU
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Code { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
