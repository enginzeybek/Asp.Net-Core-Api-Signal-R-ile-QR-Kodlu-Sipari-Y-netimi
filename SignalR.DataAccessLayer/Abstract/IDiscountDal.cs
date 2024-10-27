using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        public void ChangeStatusToTrue(int id);

		public void ChangeStatusToFalse(int id);

        public List<Discount> GetListByStatusTrue();
	}
}
