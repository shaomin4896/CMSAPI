using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementAPI.Models
{
    public class UrineTest
    {
        public int Id { get; set; }
        public DateTime TestDate { get; set; }
        public bool DidRoutine { get; set; }
        public double LDL { get; set; }
        public double Microprotein { get; set; }
    }
}