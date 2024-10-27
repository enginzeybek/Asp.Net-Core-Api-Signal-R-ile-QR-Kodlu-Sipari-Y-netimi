using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]

		public IActionResult NotificationList()
		{
			return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll()));
		}

		[HttpGet("NotificationCountByStatusFalse")]

		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}

		[HttpGet("GetAllNotificationByFalse")]

		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}

		[HttpPost]

		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			createNotificationDto.Status = false;

			createNotificationDto.Date = DateTime.Now;

			var values = _mapper.Map<Notification>(createNotificationDto);

			//Notification notification = new Notification()
			//{
			//	Description = createNotificationDto.Description,
			//	Icon = createNotificationDto.Icon,
			//	Status = false,
			//	Type = createNotificationDto.Type,
			//	Date = DateTime.Now
			//};
			_notificationService.TAdd(values);

			return Ok("Ekleme işlemi başarı ile yapıldı.");

		}

		[HttpPut]

		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var values = _mapper.Map<Notification>(updateNotificationDto);

			//Notification notification = new Notification() 
			//{
			//	Description = updateNotificationDto.Description,
			//	Icon = updateNotificationDto.Icon,
			//	Status = updateNotificationDto.Status,
			//	Type = updateNotificationDto.Type,
			//	Date = updateNotificationDto.Date,
			//	NotificationID = updateNotificationDto.NotificationID
			//};
			_notificationService.TUpdate(values);

			return Ok("Güncelleme işlemi başarı ile yapıldı");
		}

		[HttpDelete("{id}")]

		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);

			_notificationService.TDelete(value);

			return Ok("Silme işlemi başarı ile yapıldı");
		}

		[HttpGet("{id}")]

		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);

			return Ok(_mapper.Map<GetNotificationDto>(value));
		}

		[HttpGet("NotificationChangeToTrue/{id}")]

		public IActionResult NotificationChangeToTrue(int id)
		{
			_notificationService.TNotificationChangeToTrue(id);

			return Ok("Güncelleme işlemi başarılı");
		}

		[HttpGet("NotificationChangeToFalse/{id}")]

		public IActionResult NotificationChangeToFalse(int id)
		{
			_notificationService.TNotificationChangeToFalse(id);

			return Ok("Güncelleme işlemi başarılı");
		}
	}
}
