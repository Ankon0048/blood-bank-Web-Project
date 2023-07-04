using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class EventData
    {
        [DisplayName("Event Name")]
        public string? EventName { get; set; }

        [Key]
        [DisplayName("Donor ID")]
        public string? DonorID { get; set; }

        [DisplayName("Full Name")]
        public string? DonorName { get; set; }

        [DisplayName("Blood Group")]
        public string? BloodType { get; set; }

        [DisplayName("Amount(L)")]
        public int? Amount { get; set; }

        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Address")]
        public string? Address { get; set; }
    }
}