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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var context = new SignalRContext();
			
			return context.Categories.Where(x => x.CategoryStatus == true).Count();
		}

		public int CategoryCount()
		{
			using var context = new SignalRContext();

			return context.Categories.Count();
		}

		public int PassiveCategoryCount()
		{
			using var context = new SignalRContext();

			return context.Categories.Where(x =>x.CategoryStatus == false).Count();
		}
	}
}
