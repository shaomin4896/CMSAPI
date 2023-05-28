using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagementApp.Models.ControlItems
{
    public class QueryPayload
	{
		public int? CaseId { get; set; }
		public string? PatientName { get; set; }
		public string? CustomerId { get; set; }
		public DateTime? TestDate { get; set; }
	}
}