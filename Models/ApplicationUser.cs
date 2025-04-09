using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebIot.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for devices owned by this user
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
} 