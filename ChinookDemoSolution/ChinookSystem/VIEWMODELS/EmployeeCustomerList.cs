using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.VIEWMODELS
{
	public class EmployeeCustomerList
	{
		public string EmployeeName { get; set; }
		public string Title { get; set; }
		public int CustomersSupportCount { get; set; }
		public IEnumerable<CustomerSupportItem> CustomerList { get; set; }
	}
}
