using System.Collections.Generic;

namespace Web_IoT.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? FirmwareVersion { get; set; }
        public List<Measurement>? Measurements { get; set; }
    }
}
