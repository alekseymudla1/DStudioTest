namespace API.Models
{
	public record TodoDTO(
		Guid Id,
		string Name,
		string Status,
		string CreationDate,
		string LastModifiedDate
	);
}
