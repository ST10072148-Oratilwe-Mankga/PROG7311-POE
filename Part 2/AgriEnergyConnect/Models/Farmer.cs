using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class Farmer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FarmLocation { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FarmType { get; set; } = string.Empty; // e.g., "Maize", "Wheat", "Dairy", etc.

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Navigation property for products
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
} 