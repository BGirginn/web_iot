using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_IoT.Models
{
    public class DeviceCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string CodeContent { get; set; } = "";

        [Required]
        public string Language { get; set; } = ""; // Örn: c, cpp, py, js

        // Hangi cihaza ait
        [Required]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public Device Device { get; set; } = null!;
    }
}
