using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class ReportData
    {
        [DisplayName("User ID")]
        public string? UserId { get; set; }

        [DisplayName("Full Name")]
        public string? UserName { get; set; }

        [DisplayName("BloodGroup")]
        public string? Bloodgroup { get; set; }

        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Status")]
        public string? Status { get; set; }

        [DisplayName("Amount")]
        public int? Amount { get; set; }

        [DisplayName("Action")]
        public string? Action { get; set; }

        [DisplayName("Date")]
        public string? Date { get; set; }

        [DisplayName("Location")]
        public string? Location { get; set; }

        [Key]
        public int? Count { get; set; }
    }
}