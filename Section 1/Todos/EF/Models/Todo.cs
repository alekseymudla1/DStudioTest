using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
	public class Todo
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IsCompleted { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public Guid UserId { get; set; }

		public User User { get; set; }
	}
}
