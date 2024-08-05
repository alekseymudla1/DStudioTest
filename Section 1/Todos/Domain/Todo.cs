namespace Domain
{
	public class Todo
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Status { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime LastModifiedDate { get; set; }
	}
}
