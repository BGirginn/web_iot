using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_IoT.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DeviceName { get; set; } = "";

        [Required]
        public string DeviceType { get; set; } = ""; // ESP32, RPi, vb.

        public string? VendorId { get; set; }
        public string? ProductId { get; set; }

        public string? FirmwareVersion { get; set; }

        // İlişki: Kullanıcı
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; } = null!;

        // Kodlar
        public ICollection<DeviceCode> Codes { get; set; } = new List<DeviceCode>();
    }
}
