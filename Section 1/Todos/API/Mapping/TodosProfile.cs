using API.Models;
using AutoMapper;

namespace API.Mapping
{
	public class TodosProfile : Profile
	{
		public TodosProfile() 
		{
			CreateMap<EF.Models.Todo, Domain.Todo>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Title))
				.ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
				.ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.IsCompleted ? "Completed" : "Active"))
				.ForMember(dst => dst.CreationDate, opt => opt.MapFrom(src => src.CreatedAt))
				.ForMember(dst => dst.LastModifiedDate, opt => opt.MapFrom(src => src.UpdatedAt));

			CreateMap<Domain.Todo, TodoDTO>();
		}
	}
}
