using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpGet("TotalOrderCount")]

		public ActionResult TotalOrderCount()
		{
			return Ok(_orderService.TTotalOrderCount());
		}

		[HttpGet("ActiveOrderCount")]

		public ActionResult ActiveOrderCount()
		{
			return Ok(_orderService.TActiveOrderCount());
		}

		[HttpGet("LastOrderPrice")]

		public ActionResult LastOrderPrice()
		{
			return Ok(_orderService.TLastOrderPrice());
		}

		[HttpGet("TodayTotalPrice")]

		public ActionResult TodayTotalPrice()
		{
			return Ok(_orderService.TTodayTotalPrice());
		}

		[HttpGet]

		public IActionResult OrderList()
		{
			var values = _orderService.TGetListAll();

			return Ok(_mapper.Map<List<ResultOrderDto>>(values));
		}

		[HttpGet("id")]

		public ActionResult GetOrder(int id)
		{
			var values = _orderService.TGetById(id);

			return Ok(_mapper.Map<GetOrderDto>(values));
		}

		[HttpPost]

		public IActionResult CreateOrder(CreateOrderDto createOrderDto)
		{
			var values = _mapper.Map<Order>(createOrderDto);

			_orderService.TAdd(values);

			return Ok("Sipariş bilgisi eklendi");
		}

		[HttpDelete("id")]

		public IActionResult DeleteOrder(int id)
		{
			var values = _orderService.TGetById(id);

			_orderService.TDelete(values);

			return Ok("Sipariş silindi");
		}

		[HttpPut]

		public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
		{
			var values = _mapper.Map<Order>(updateOrderDto); 
			
			_orderService.TUpdate(values);

			return Ok("Sipariş bilgisi güncellendi");
		}
	}
}
