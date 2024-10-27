using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		//[HttpGet]  İlk yol olarak bu kullanılır. Bir de automapper ile de bu işlemi gerçekleştirebiliriz.

  //      public IActionResult AboutList()
  //      {
  //          var values = _aboutService.TGetListAll();
  //          return Ok(values);
  //      }

		[HttpGet]

		public IActionResult AboutList()
		{
			var values = _aboutService.TGetListAll();
			return Ok(_mapper.Map<List<ResultAboutDto>>(values));
		}

		[HttpPost]

        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);


            //About about = new About() // bunun yerine de map işlemini tek satırda halledebiliriz.
            //{
            //    Title = createAboutDto.Title,
            //    Description = createAboutDto.Description,
            //    ImageUrl = createAboutDto.ImageUrl,
            //};

            _aboutService.TAdd(values);  // _aboutService.TAdd(about);
			return Ok("HAKKIMDA KISMI BAŞARILI BİR ŞEKİLDE EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("HAKKIMDA ALANI SİLİNDİ");
        }

        [HttpPut]

        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var values = _mapper.Map<About>(updateAboutDto);

            //About about = new About()
            //{
            //    AboutID = updateAboutDto.AboutID,
            //    Title = updateAboutDto.Title,
            //    Description = updateAboutDto.Description,
            //    ImageUrl = updateAboutDto.ImageUrl,
            //};
            _aboutService.TUpdate(values); // _aboutService.TUpdate(about);
			return Ok("HAKKIMDA ALANI GÜNCELLENDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDto>(value));

            //return Ok(value);
        }
    }
}
