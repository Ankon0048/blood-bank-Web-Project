using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class HospitalDesc
    {
        [Key]
        [DisplayName("Hospital Name")]
        public string? HospitalName { get; set; }

        [DisplayName("Location")]
        public string? Location { get; set; }

        [DisplayName("District")]
        public string? District { get; set; }

        [DisplayName("Emergency Contact Number")]
        public string? Number { get; set; }

        [DisplayName("Email")]
        public string? Email { get; set; }

        [DisplayName("Upload Image")]
        public string? Imageurl { get; set; }
    }
}