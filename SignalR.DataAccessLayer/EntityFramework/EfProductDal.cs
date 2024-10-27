using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repository;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();

            var values = context.Products.Include(x => x.Category).ToList();

            return values;
        }

		public int ProductCount()
		{
			using var context = new SignalRContext();

            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.CategoryID ==
			(context.Categories.Where(y => y.CategoryName == "İçecek").Select
			(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.CategoryID ==
			(context.Categories.Where(y => y.CategoryName == "Hamburger").Select
			(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.ProductPrice == (context.Products.Max
			(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.ProductPrice == (context.Products.Min
			(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();

			return context.Products.Average(x => x.ProductPrice);
		}

		public decimal ProductAvgPriceByHumberger()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.CategoryID == (context.Categories.
			Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault()))
			.Average(w => w.ProductPrice);
		}

		public decimal ProductPriceBySteakBurger()
		{
			using var context = new SignalRContext();

			return context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.ProductPrice)
				.FirstOrDefault();
		}

		public decimal TotalPriceByDrinkCategory()
		{
			using var context = new SignalRContext();

			int id = context.Categories.Where(y => y.CategoryName == "İçecek").
				Select(z =>z.CategoryID).FirstOrDefault();

			return context.Products.Where(x => x.CategoryID == id).Sum(y => y.ProductPrice);
		}

		public List<Product> GetLast9Products()
		{
			using var context = new SignalRContext();

			return context.Products.Take(9).ToList();
		}
	}
}
