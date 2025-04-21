using System;

namespace Web_IoT.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device? Device { get; set; } // ← İŞTE BU SATIR

        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}
