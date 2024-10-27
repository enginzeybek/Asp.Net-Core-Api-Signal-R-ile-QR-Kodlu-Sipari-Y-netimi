using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _Mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _Mapper = mapper;
        }

        [HttpGet]

        public IActionResult CategoryList() 
        { 
            var value = _Mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("CategoryCount")]

        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

		[HttpGet("ActiveCategoryCount")]

		public IActionResult ActiveCategoryCount()
		{
			return Ok(_categoryService.TActiveCategoryCount());
		}

		[HttpGet("PassiveCategoryCount")]

		public IActionResult PassiveCategoryCount()
		{
			return Ok(_categoryService.TPassiveCategoryCount());
		}

		[HttpPost]

        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.CategoryStatus = true;

            var values = _Mapper.Map<Category>(createCategoryDto);

            _categoryService.TAdd(values);

            //_categoryService.TAdd(new Category()
            //{
            //    CategoryName = createCategoryDto.CategoryName,
            //    CategoryStatus = true,
            //});

            return Ok("KATEGORİ EKLENDİ");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
            return Ok("KATEGORİ SİLİNDİ");
        }

        [HttpGet("{id}")]

        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            return Ok(_Mapper.Map<GetCategoryDto>(values));
        }

        [HttpPut]

        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = _Mapper.Map<Category>(updateCategoryDto);

            _categoryService.TUpdate(values);

            //_categoryService.TUpdate(new Category()
            //{
            //    CategoryName = updateCategoryDto.CategoryName,
            //    CategoryStatus = updateCategoryDto.CategoryStatus,
            //    CategoryID = updateCategoryDto.CategoryID,
            //});
            return Ok("KATEGORİ GÜNCELLENDİ");
        }
    }
}
