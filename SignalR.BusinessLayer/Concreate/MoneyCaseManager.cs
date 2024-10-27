using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concreate
{
	public class MoneyCaseManager : IMoneyCasesService
	{
		readonly private IMoneyCasesDal _moneyCasesDal;

		public MoneyCaseManager(IMoneyCasesDal moneyCasesDal)
		{
			_moneyCasesDal = moneyCasesDal;
		}

		public void TAdd(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public MoneyCase TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public decimal TTotalMoneyCaseAmount()
		{
			return _moneyCasesDal.TotalMoneyCaseAmount();
		}

		public void TUpdate(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
