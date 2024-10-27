using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.MoneyCasesDto
{
	public class GetMoneyCasesDto
	{
		public int MoneyCaseID { get; set; }

		public decimal TotalAmount { get; set; }
	}
}
