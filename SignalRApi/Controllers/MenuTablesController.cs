using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet("MenuTableCount")]

		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

		[HttpGet]

		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
		}

		[HttpPost]

		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			createMenuTableDto.Status = false;

			var values = _mapper.Map<MenuTable>(createMenuTableDto);

			//MenuTable menuTable = new MenuTable()
			//{
			//	Name = createMenuTableDto.Name,
			//	Status = false
			//};

			_menuTableService.TAdd(values);
			return Ok("MASA BAŞARILI BİR ŞEKİLDE EKLENDİ");
		}

		[HttpDelete("{id}")]

		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("MASA SİLİNDİ");
		}

		[HttpPut]

		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var values = _mapper.Map<MenuTable>(updateMenuTableDto);

			//MenuTable menuTable = new MenuTable()
			//{
			//	MenuTableID = updateMenuTableDto.MenuTableID,
			//	Name = updateMenuTableDto.Name,
			//	Status = false
			//};

			_menuTableService.TUpdate(values);
			return Ok("MASA GÜNCELLENDİ");
		}

		[HttpGet("{id}")]

		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(_mapper.Map<GetMenuTableDto>(value));
		}

		[HttpGet("ChangeMenuTableStatusToTrue")]

		public IActionResult ChangeMenuTableStatusToTrue(int id)
		{
			_menuTableService.TChangeMenuTableStatusToTrue(id);

			return Ok("İşlem Başarılı");
		}

        [HttpGet("ChangeMenuTableStatusToFalse")]

        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);

            return Ok("İşlem Başarılı");
        }

    }
}
