using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_IoT.Models
{
    public class DeviceCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty; // önceki CodeContent buydu

        [Required]
        public string Language { get; set; } = string.Empty; // Örn: c, cpp, py, js

        [Required]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public Device Device { get; set; } = null!;
    }
}
