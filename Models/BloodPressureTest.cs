using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementAPI.Models
{
    public class BloodPressureTest
    {
        public int Id { get; set; }
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
    }
}