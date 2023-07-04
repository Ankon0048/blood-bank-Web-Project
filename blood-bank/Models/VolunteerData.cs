using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class VolunteerData
    {
        [Key]
        [DisplayName("Volunteer ID")]
        public string? VolunteerID { get; set; }

        [DisplayName("Full Name")]
        public string? Name { get; set; }

        [DisplayName("Blood Group")]
        public string? Bloodgroup { get; set; }

        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Address")]
        public string? Address { get; set; }
    }
}