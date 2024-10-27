﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();

			var value = context.Discounts.Find(id);

			value.Status = false;

			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();

			var value = context.Discounts.Find(id);

			value.Status = true;

			context.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var context = new SignalRContext();

			return context.Discounts.Where(x => x.Status == true).ToList();
		}
	}
}