using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_IoT.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DeviceName { get; set; } = string.Empty;

        [Required]
        public string DeviceType { get; set; } = string.Empty;

        public string? VendorId { get; set; }
        public string? ProductId { get; set; }
        public string? FirmwareVersion { get; set; }

        // Kullanıcı ile ilişki
        [Required]
        public string UserId { get; set; } = string.Empty; // Identity FK

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        // Cihaza ait kodlar
        public ICollection<DeviceCode>? Codes { get; set; }
    }
}
