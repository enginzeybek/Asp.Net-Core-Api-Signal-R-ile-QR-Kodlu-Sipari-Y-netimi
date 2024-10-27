using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]

		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));
		}

		[HttpPost]

		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.Status = false;

			createMessageDto.MessageSendDate = DateTime.Now;

			var values = _mapper.Map<Message>(createMessageDto);

			


			//Message message = new Message()
			//{
			//	NameSurname = createMessageDto.NameSurname,
			//	Mail = createMessageDto.Mail,
			//	Phone = createMessageDto.Phone,
			//	MessageContent = createMessageDto.MessageContent,
			//	Status = false,
			//	Subject = createMessageDto.Subject,
			//	MessageSendDate = DateTime.Now
			//};

			_messageService.TAdd(values);
			return Ok("MESAJ BAŞARILI BİR ŞEKİLDE GÖNDERİLDİ");
		}

		[HttpDelete("{id}")]

		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);
			return Ok("MESAJ SİLİNDİ");
		}

		[HttpPut]

		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var values = _mapper.Map<Message>(updateMessageDto);

			//Message message = new Message()
			//{
			//	MessageID = updateMessageDto.MessageID,
			//	Mail = updateMessageDto.Mail,
			//	Phone = updateMessageDto.Phone,
			//	MessageContent = updateMessageDto.MessageContent,
			//	Status = false,
			//	Subject = updateMessageDto.Subject,
			//	MessageSendDate = updateMessageDto.MessageSendDate,
			//	NameSurname = updateMessageDto.NameSurname
			//};

			_messageService.TUpdate(values);
			return Ok("MESAJ BİLGİSİ GÜNCELLENDİ");
		}

		[HttpGet("{id}")]

		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);
			return Ok(_mapper.Map<GetMessageDto>(value));
		}
	}
}

