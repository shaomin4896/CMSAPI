using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementAPI.Models
{
    public class EyeTest
    {
        public int Id { get; set; }
        public DateTime TestDate { get; set; }
        public bool IsNormal { get; set; }
    }
}