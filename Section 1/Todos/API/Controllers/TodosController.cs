using API.Models;
using AutoMapper;
using Domain.Interfaces;
using EF.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodosController : ControllerBase
	{
		private readonly ITodosLogic _logic;
		private readonly IMapper _mapper;
		public TodosController(ITodosLogic logic, IMapper mapper)
		{
			_logic = logic;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<TodoDTO>> GetTasks()
		{
			var tasks = await _logic.GetAllTodosAsync();
			return _mapper.Map<IEnumerable<TodoDTO>>(tasks);
		}
	}
}
