using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class EventDesc
    {
        [Key]
        [DisplayName("Event Name")]
        public string? EventName { get; set; }

        [DisplayName("Total Blood Collected(L)")]
        public int? BloodCollected { get; set; }

        [DisplayName("Location")]
        public string? Location { get; set; }

        [DisplayName("Date of Event")]
        public string? Date { get; set; }

        [DisplayName("Start to End Time")]
        public string? Time { get; set; }

        [DisplayName("Status")]
        public string? Status { get; set; }

        [DisplayName("Upload Image")]
        public string? Imageurl { get; set; }
    }
}