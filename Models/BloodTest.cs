using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementAPI.Models
{
    public class BloodTest
    {
        public int Id { get; set; }
        public DateTime TestDate { get; set; }
        public double? HBAIC { get; set; }
        public double BloodSugarBeforeMeal { get; set; }
        public double BloodSugarAfterMeal { get; set; }
        public double? TG { get; set; }
        public double? Creatinine { get; set; }
    }
}