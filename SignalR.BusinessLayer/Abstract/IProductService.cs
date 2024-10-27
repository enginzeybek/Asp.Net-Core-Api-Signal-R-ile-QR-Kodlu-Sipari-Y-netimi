﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();

        public int TProductCount();

		public int TProductCountByCategoryNameHamburger();

		public int TProductCountByCategoryNameDrink();

		public decimal TProductPriceAvg();

		public string TProductNameByMaxPrice();

		public string TProductNameByMinPrice();

		public decimal TProductAvgPriceByHumberger();

		public decimal TProductPriceBySteakBurger();

		public decimal TTotalPriceByDrinkCategory();

		public List<Product> TGetLast9Products();
	}
}