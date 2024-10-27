using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        private readonly IMapper _Mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _Mapper = mapper;
        }

        [HttpGet]

        public IActionResult ContactList()
        {
            var value = _Mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]

        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var values = _Mapper.Map<Contact>(createContactDto);

            _contactService.TAdd(values);

            //_contactService.TAdd(new Contact()
            //{
            //    FooterDescription = createContactDto.FooterDescription,
            //    Location = createContactDto.Location,
            //    Mail = createContactDto.Mail,
            //    Phone = createContactDto.Phone,
            //    FooterTitle = createContactDto.FooterTitle,
            //    OpenDays = createContactDto.OpenDays,
            //    OpenDaysDescription = createContactDto.OpenDaysDescription,
            //    OpenHours = createContactDto.OpenHours,
            //});

            return Ok("İLETİŞİM BİLGİSİ EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);
            _contactService.TDelete(values);
            return Ok("İLETİŞİM BİLGİSİ SİLİNDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetById(id);
            return Ok(_Mapper.Map<GetContactDto>(values));
        }

        [HttpPut]

        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var values = _Mapper.Map<Contact>(updateContactDto);

            _contactService.TUpdate(values);

            //_contactService.TUpdate(new Contact()
            //{
            //    ContactID = updateContactDto.ContactID,
            //    FooterDescription=updateContactDto.FooterDescription,
            //    Location=updateContactDto.Location,
            //    Mail=updateContactDto.Mail,
            //    Phone=updateContactDto.Phone,
            //    FooterTitle = updateContactDto.FooterTitle,
            //    OpenDays=updateContactDto.OpenDays,
            //    OpenDaysDescription=updateContactDto.OpenDaysDescription,
            //    OpenHours=updateContactDto.OpenHours
            //});
            return Ok("İLETİŞİM BİLGİSİ GÜNCELLENDİ");
        }
    }
}
