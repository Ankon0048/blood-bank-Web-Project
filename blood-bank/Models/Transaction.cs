using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class Transaction
    {
        [DisplayName("User ID")]
        public string? UserId { get; set; }

        [DisplayName("Full Name")]
        public string? UserName { get; set; }

        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Transaction ID")]
        public string? TrixID { get; set; }

        [Key]
        public int? Count { get; set; }

        [DisplayName("Amount(BDT)")]
        public int? Amount { get; set; }

        [DisplayName("Date")]
        public string? Date { get; set; }
    }
}