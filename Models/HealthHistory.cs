using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CaseManagementAPI.Extensions;

namespace CaseManagementAPI.Models
{
    public class HealthHistory
    {
        public int Id { get; set; }
        public DateTime TraceDate { get; set; }
        public string TraceItemJson { get; set; }
        [NotMapped]
        public bool[] TraceItem { get => TraceItemJson.JsonDeserialize<bool[]>(); set => TraceItemJson = value.ToJsonString(); }
        public CmsUser? Manager { get; set; }
        public string Content { get; set; }
    }
}