using Domain;
using Domain.Interfaces;

namespace Logic
{
	public class TodosLogic : ITodosLogic
	{
		private readonly ITodosRepository _repository;

		public TodosLogic(ITodosRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Todo>> GetAllTodosAsync()
		{
			return await _repository.GetAllTodosAsync();
		}
	}
}
