using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.DtoLayer.MoneyCasesDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCasesController : ControllerBase
	{
		readonly private IMoneyCasesService _moneyCasesService;
		readonly private IMapper _mapper;

		public MoneyCasesController(IMoneyCasesService moneyCasesService, IMapper mapper)
		{
			_moneyCasesService = moneyCasesService;
			_mapper = mapper;
		}

		[HttpGet("TotalMoneyCaseAmount")]

		public IActionResult TotalMoneyCaseAmount()
		{
			return Ok(_moneyCasesService.TTotalMoneyCaseAmount());
		}

		[HttpGet]

		public IActionResult MoneyCasesList()
		{
			var values = _moneyCasesService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMoneyCasesDto>>(values));
		}

		[HttpPost]

		public IActionResult CreateMoneyCases(CreateMoneyCasesDto createMoneyCasesDto)
		{
			var values = _mapper.Map<MoneyCase>(createMoneyCasesDto);
			_moneyCasesService.TAdd(values);
			return Ok("KASA BAŞARILI BİR ŞEKİLDE OLUŞTURULDU");
		}

		[HttpDelete("{id}")]

		public IActionResult DeleteMoneyCases(int id)
		{
			var value = _moneyCasesService.TGetById(id);
			_moneyCasesService.TDelete(value);
			return Ok("KASA SİLİNDİ");
		}

		[HttpPut]

		public IActionResult UpdateMoneyCases(UpdateMoneyCasesDto updateMoneyCasesDto)
		{
			var values = _mapper.Map<MoneyCase>(updateMoneyCasesDto);
			_moneyCasesService.TUpdate(values);
			return Ok("KASA BİLGİSİ GÜNCELLENDİ");
		}

		[HttpGet("{id}")]

		public IActionResult GetMoneyCases(int id)
		{
			var value = _moneyCasesService.TGetById(id);
			return Ok(_mapper.Map<GetMoneyCasesDto>(value));
		}
	}
}
