using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        private readonly IMapper _Mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _Mapper = mapper;
        }

        [HttpGet]

        public IActionResult DiscountList()
        {
            var value = _Mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]

        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var values = _Mapper.Map<Discount>(createDiscountDto);

            _discountService.TAdd(values);

            //_discountService.TAdd(new Discount()
            //{
            //    Amount = createDiscountDto.Amount,
            //    DiscountDescription = createDiscountDto.DiscountDescription,
            //    DiscountTitle = createDiscountDto.DiscountTitle,
            //    ImageUrl = createDiscountDto.ImageUrl,
            //    Status = false
            //});

            return Ok("İNDİRİM BİLGİSİ EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            _discountService.TDelete(values);
            return Ok("İNDİRİM BİLGİSİ SİLİNDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            return Ok(_Mapper.Map<GetDiscountDto>(values));
        }

        [HttpPut]

        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var values = _Mapper.Map<Discount>(updateDiscountDto);

            _discountService.TUpdate(values);

            //_discountService.TUpdate(new Discount()
            //{
            //    DiscountID = updateDiscountDto.DiscountID,
            //    DiscountDescription = updateDiscountDto.DiscountDescription,
            //    DiscountTitle = updateDiscountDto.DiscountTitle,
            //    Amount = updateDiscountDto.Amount,
            //    ImageUrl= updateDiscountDto.ImageUrl,
            //    Status = false
            //});
            return Ok("İNDİRİM BİLGİSİ GÜNCELLENDİ");
        }

        [HttpGet("ChangeStatusToTrue/{id}")]

        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);

            return Ok("Ürün İndirimi Aktif Hale Getirildi");
        }

		[HttpGet("ChangeStatusToFalse/{id}")]

		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);

			return Ok("Ürün İndirimi Pasif Hale Getirildi");
		}

        [HttpGet("GetListByStatusTrue")]

        public IActionResult GetListByStatusTrue()
        {
            var value = _discountService.TGetListByStatusTrue();

            return Ok(value);
        }

	}
}
