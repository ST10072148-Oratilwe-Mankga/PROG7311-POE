using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty; // e.g., "Grains", "Vegetables", "Fruits", "Dairy"

        [Required]
        public DateTime ProductionDate { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }

        [StringLength(50)]
        public string? Unit { get; set; } // e.g., "kg", "tons", "liters"

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsAvailable { get; set; } = true;

        // Foreign key for Farmer
        public int FarmerId { get; set; }
        public virtual Farmer Farmer { get; set; } = null!;
    }
} 