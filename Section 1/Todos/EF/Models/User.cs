using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
	public class User
	{
		//[PrimaryKey("UserId")]
		public Guid UserId { get; set; }


	}
}
