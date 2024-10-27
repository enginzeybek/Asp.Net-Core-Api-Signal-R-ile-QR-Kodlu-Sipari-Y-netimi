using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketByMenuTableNumber")]

        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            return Ok(_basketService.TGetBasketByMenuTableNumber(id));
        }

        [HttpGet("BasketListByMenuTableWithProductName")]

        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();

            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select
                (z => new ResultBasketListWithProducts
                {
                    BasketID = z.BasketID,
                    Count = z.Count,
                    MenuTableID = z.MenuTableID,
                    Price = z.Price,
                    ProductID = z.ProductID,
                    TotalPrice = z.TotalPrice,
                    ProductName = z.Product.ProductName
                }).ToList();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();

            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                MenuTableID=createBasketDto.MenuTableID,
                Count = 1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID)
                .Select(y => y.ProductPrice).FirstOrDefault(),
                TotalPrice = createBasketDto.TotalPrice
            });
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);

            _basketService.TDelete(value);

            return Ok("SEPETTEKİ SEÇİLEN ÜRÜN SİLİNDİ");
        }
    }
}
