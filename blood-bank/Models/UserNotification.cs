using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class UserNotification
    {
        [DisplayName("User ID")]
        public string? UserId { get; set; }

        [DisplayName("Status")]
        public string? Status { get; set; }

        [DisplayName("Message")]
        public string? Message { get; set; }

        [DisplayName("Date")]
        public string? Date { get; set; }

        [DisplayName("Mark(unread or read)")]
        public string? Mark { get; set; }

        [Key]
        public int? Count { get; set; }
    }
}