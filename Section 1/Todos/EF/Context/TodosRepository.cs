using AutoMapper;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Context
{
	public class TodosRepository : ITodosRepository
	{
		private readonly TodosContext _todosContext;
		private readonly IMapper _mapper;

		public TodosRepository(TodosContext todosContext, IMapper mapper) 
		{ 
			_todosContext = todosContext;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Todo>> GetAllTodosAsync()
		{
			var data = await _todosContext.Todos.AsNoTracking().ToListAsync();
			return _mapper.Map<IEnumerable<Todo>>(data);
		}
	}
}
