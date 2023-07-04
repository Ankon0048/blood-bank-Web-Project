using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class Userprofile
    {
        [Key]
        [DisplayName("UserID")]
        public string? UserID { get; set; }

        [DisplayName("Full Name")]
        public string? UserName { get; set; }

        [DisplayName("Email")]
        public string? Email { get; set; }

        [DisplayName("Address")]
        public string? Address { get; set; }

        [DisplayName("Password")]
        public string? Password { get; set; }

        [DisplayName("Blood Group")]
        public string? Bloodgrp { get; set; }

        [DisplayName("Contact Number")]
        public string? Number { get; set; }

        [DisplayName("NID or Birth Certificate ID")]
        public string? NID { get; set; }

        [DisplayName("Role")]
        public string? Role { get; set; }

        [DisplayName("Upload Image")]
        public string? Imageurl { get; set; }

        [DisplayName("Date of Birth")]
        public string? DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public string? Gender { get; set; }
    }
}