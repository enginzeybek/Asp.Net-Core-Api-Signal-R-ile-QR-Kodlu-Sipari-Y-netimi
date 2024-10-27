using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        private readonly IMapper _Mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _Mapper = mapper;
        }

        [HttpGet]

        public IActionResult TestimonialList()
        {
            var value = _Mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]

        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var values = _Mapper.Map<Testimonial>(createTestimonialDto);

            _testimonialService.TAdd(values);

            //_testimonialService.TAdd(new Testimonial()
            //{
            //    Comment = createTestimonialDto.Comment,
            //    ImageUrl = createTestimonialDto.ImageUrl,
            //    Name = createTestimonialDto.Name,
            //    Status = createTestimonialDto.Status,
            //    Title = createTestimonialDto.Title
            //});

            return Ok("MÜŞTERİ YORUM BİLGİSİ EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok("MÜŞTERİ YORUM BİLGİSİ SİLİNDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(_Mapper.Map<GetTestimonialDto>(values));
        }

        [HttpPut]

        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var values = _Mapper.Map<Testimonial>(updateTestimonialDto);

            _testimonialService.TUpdate(values);

            //_testimonialService.TUpdate(new Testimonial()
            //{
            //    TestimonialID = updateTestimonialDto.TestimonialID,
            //    Comment = updateTestimonialDto.Comment,
            //    Title = updateTestimonialDto.Title,
            //    Status = updateTestimonialDto.Status,
            //    Name = updateTestimonialDto.Name,
            //    ImageUrl = updateTestimonialDto.ImageUrl
            //});

            return Ok("MÜŞTERİ YORUM BİLGİSİ GÜNCELLENDİ");

        }
    }
}
