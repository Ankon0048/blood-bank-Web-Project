using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class BloodStory
    {
        [DisplayName("User ID")]
        public string? UserId { get; set; }

        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Email")]
        public string? Email { get; private set; }

        [DisplayName("Story")]
        public string? Story { get; set; }

        [Key]
        public int? Count { get; set; }

        [DisplayName("Full Name")]
        public string? UserName { get; set; }

        [DisplayName("Current Date")]
        public string? Date { get; set; }

        [DisplayName("Upload Image")]
        public string? Imageurl { get; set; }
    }
}