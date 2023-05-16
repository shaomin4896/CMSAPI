using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementAPI.Models
{
    public class PatientSelfHistory
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string MedicineRecord { get; set; }
        public int FootCare { get; set; }
        public int SportCare { get; set; }
        public int MouseCare { get; set; }
        public BloodPressureTest BloodPressureTest { get; set; }
        public FootTest FootTest { get; set; }
        public BloodTest BloodTest { get; set; }
    }
}