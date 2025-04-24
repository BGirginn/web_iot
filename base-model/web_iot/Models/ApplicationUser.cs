using Microsoft.AspNetCore.Identity;

namespace Web_IoT.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }

        public ICollection<Device>? Devices { get; set; }
    }
}
