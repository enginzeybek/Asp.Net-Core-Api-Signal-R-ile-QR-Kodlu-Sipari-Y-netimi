using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _Mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _Mapper = mapper;
        }

        [HttpGet]

        public IActionResult ProductList()
        {
            var value = _Mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("ProductAvgPriceByHumberger")]

        public IActionResult ProductAvgPriceByHumberger()
        {
            return Ok(_productService.TProductAvgPriceByHumberger());
        }

        [HttpGet("ProductCount")]

        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductNameByMaxPrice")]

        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

		[HttpGet("ProductNameByMinPrice")]

		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}

        [HttpGet("ProductPriceBySteakBurger")]

        public IActionResult ProductPriceBySteakBurger()
        {
            return Ok(_productService.TProductPriceBySteakBurger());
        }

        [HttpGet("TotalPriceByDrinkCategory")]

        public IActionResult TotalPriceByDrinkCategory()
        {
            return Ok(_productService.TTotalPriceByDrinkCategory());
        }

		[HttpGet("ProductPriceAvg")]

        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

		[HttpGet("ProductCountByDrink")]

		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ProductCountByHamburger")]

		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductListWithCategory")]

        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();

            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductDescription = y.ProductDescription,
                ImageUrl = y.ImageUrl,
                CategoryName = y.Category.CategoryName,
                ProductName = y.ProductName,
                ProductID = y.ProductID,
                ProductPrice = y.ProductPrice,
                ProductStatus = y.ProductStatus,
            });

            return Ok(values.ToList());
        }

        [HttpPost]

        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var values = _Mapper.Map<Product>(createProductDto);

            _productService.TAdd(values);

            //_productService.TAdd(new Product()
            //{
            //    ProductName = createProductDto.ProductName,
            //    ProductDescription = createProductDto.ProductDescription,
            //    ProductPrice = createProductDto.ProductPrice,
            //    ProductStatus = createProductDto.ProductStatus,
            //    ImageUrl = createProductDto.ImageUrl,
            //    CategoryID = createProductDto.CategoryID,
            //});

            return Ok("ÜRÜN BİLGİSİ EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return Ok("ÜRÜN BİLGİSİ SİLİNDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetProduct(int id)
        {
            var values = _productService.TGetById(id);
            return Ok(_Mapper.Map<GetProductDto>(values));
        }

        [HttpPut]

        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _Mapper.Map<Product>(updateProductDto); 
            
            _productService.TUpdate(values);

            //_productService.TUpdate(new Product()
            //{
            //    ProductID = updateProductDto.ProductID,
            //    ProductName = updateProductDto.ProductName,
            //    ProductDescription = updateProductDto.ProductDescription,
            //    ProductPrice = updateProductDto.ProductPrice,
            //    ProductStatus = updateProductDto.ProductStatus,
            //    ImageUrl = updateProductDto.ImageUrl,
            //    CategoryID = updateProductDto.CategoryID,
            //});

            return Ok("ÜRÜN BİLGİSİ GÜNCELLENDİ");
        }

		[HttpGet("GetLast9Products")]

        public IActionResult GetLast9Products()
        {
            var values = _productService.TGetLast9Products();

            return Ok(values);
        }
	}
}
