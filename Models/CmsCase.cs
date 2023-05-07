using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementAPI.Models
{
    public class CmsCase
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PatientName { get; set; }
        public bool IsMale { get; set; }
        public string CustomerId { get; set; }
        public DateTime Birthday { get; set; }
        public string DoctorName { get; set; }
        public DateTime SeekDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EndReason { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Waistline { get; set; }
        public string AllergyMd { get; set; }
        public string MedicalHistory { get; set; }
        public string FamilyMedicalHistory { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Contactor { get; set; }
        public CmsUser Manger { get; set; }
        public CmsUser Patient { get; set; }
        public List<BloodTest> BloodTests { get; set; }
        public List<EyeTest> EyeTests { get; set; }
        public List<FootTest> FootTests { get; set; }
        public List<UrineTest> UrineTests { get; set; }
    }
}