using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blood_bank.Models
{
    public class HospitalData
    {
        [Key]
        [DisplayName("Hospital Full Name")]
        public string? HospitalName { get; set; }

        [DisplayName("O+ Blood(L)")]
        public int? Opositive { get; set; }

        [DisplayName("O- Blood(L)")]
        public int? Onegative { get; set; }

        [DisplayName("A+ Blood(L)")]
        public int? Apositive { get; set; }

        [DisplayName("A- Blood(L)")]
        public int? Anegative { get; set; }

        [DisplayName("B+ Blood(L)")]
        public int? Bpositive { get; set; }

        [DisplayName("B- Blood(L)")]
        public int? Bnegative { get; set; }

        [DisplayName("AB+ Blood(L)")]
        public int? ABpositive { get; set; }

        [DisplayName("AB- Blood(L)")]
        public int? ABnegative { get; set; }

        [DisplayName("Maximum Capacity Blood(L)")]
        public int? Capacity { get; set; }
    }
}