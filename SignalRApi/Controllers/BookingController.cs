using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]

        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values)); // return Ok(values);
		}

        [HttpPost]

        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var values = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(values);
            return Ok("REZERVASYON YAPILDI");


            //Booking booking = new Booking()
            //{
            //    Mail = createBookingDto.Mail,
            //    Date = createBookingDto.Date,
            //    Name = createBookingDto.Name,
            //    PersonCount = createBookingDto.PersonCount,
            //    Phone = createBookingDto.Phone,
            //    Description = createBookingDto.Description
            //};


        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("REZERVASYON SİLİNDİ");
        }

        [HttpPut]

        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var values = _mapper.Map<Booking>(updateBookingDto);

            //Booking booking = new Booking()
            //{
            //    Mail = updateBookingDto.Mail,
            //    Date = updateBookingDto.Date,
            //    Name = updateBookingDto.Name,
            //    PersonCount = updateBookingDto.PersonCount,
            //    Phone = updateBookingDto.Phone,
            //    BookingID = updateBookingDto.BookingID,
            //};

            _bookingService.TUpdate(values);  // _bookingService.TUpdate(booking); 
			return Ok("REZERVASYON GÜNCELLENDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(values));  // return Ok(values);
		}

		[HttpGet("BookingStatusApproved/{id}")]

		public IActionResult BookingStatusApproved(int id)
		{
            _bookingService.TBookingStatusApproved(id);

			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}

		[HttpGet("BookingStatusCanselled/{id}")]

		public IActionResult BookingStatusCanselled(int id)
		{
            _bookingService.TBookingStatusCanselled(id);

			return Ok("Rezervasyon Açıklaması İptal Edildi");
		}

        [HttpGet("BookingCount")]

        public IActionResult BookingCount()
        {
            return Ok(_bookingService.TBookingCount());
        }
	}
}
