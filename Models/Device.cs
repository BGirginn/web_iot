using System.ComponentModel.DataAnnotations;

namespace WebIot.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PortName { get; set; } = string.Empty;

        [Required]
        public int BaudRate { get; set; } = 9600;

        [StringLength(50)]
        public string DeviceType { get; set; } = string.Empty;

        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastConnectedAt { get; set; }

        // Navigation property for the user who owns this device
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
    }
} 