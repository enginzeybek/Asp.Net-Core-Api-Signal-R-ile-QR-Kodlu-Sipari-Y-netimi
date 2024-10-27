using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        private readonly IMapper _Mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _Mapper = mapper;
        }

        [HttpGet]

        public IActionResult SocialMediaList()
        {
            var value = _Mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]

        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = _Mapper.Map<SocialMedia>(createSocialMediaDto);

            _socialMediaService.TAdd(values);

            //_socialMediaService.TAdd(new SocialMedia()
            //{
            //    Title = createSocialMediaDto.Title,
            //    Icon = createSocialMediaDto.Icon,
            //    Url = createSocialMediaDto.Url,
            //});

            return Ok("SOSYAL MEDYA BİLGİSİ EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(values);
            return Ok("SOSYAL MEDYA BİLGİSİ SİLİNDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            return Ok(_Mapper.Map<GetSocialMediaDto>(values));
        }

        [HttpPut]

        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = _Mapper.Map<SocialMedia>(updateSocialMediaDto);

            _socialMediaService.TUpdate(values);

            //_socialMediaService.TUpdate(new SocialMedia()
            //{
            //    SocialMediaID = updateSocialMediaDto.SocialMediaID,
            //    Title = updateSocialMediaDto.Title,
            //    Icon = updateSocialMediaDto.Icon,
            //    Url = updateSocialMediaDto.Url,
            //});

            return Ok("SOSYAL MEDYA BİLGİSİ GÜNCELLENDİ");

        }
    }
}
