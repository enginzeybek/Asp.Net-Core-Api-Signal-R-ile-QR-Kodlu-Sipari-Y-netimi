using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWepUI.DTOs.DiscountDTOs
{
    public class GetDiscountDto
    {
        public int DiscountID { get; set; }

        public string DiscountTitle { get; set; }

        public string Amount { get; set; }

        public string DiscountDescription { get; set; }

        public string ImageUrl { get; set; }

		public bool Status { get; set; }
	}
}
