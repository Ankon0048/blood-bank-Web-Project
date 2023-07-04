using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class AdminHomeData
    {
        [DisplayName("User ID")]
        public string? UserId { get; set; }

        [DisplayName("Full Name")]
        public string? UserName { get; set; }

        [DisplayName("Select Blood Group")]
        public string? BloodGroup { get; set; }

        public string? Status { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Current Date")]
        public string? Date { get; set; }

        [DisplayName("Address")]
        public string? Address { get; set; }

        [Key]
        public int Count { get; set; }

        public string? Email { get; set; }
    }
}