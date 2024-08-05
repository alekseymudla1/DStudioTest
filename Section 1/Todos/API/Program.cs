using API.Mapping;
using Domain.Interfaces;
using EF.Context;
using Logic;
using Microsoft.EntityFrameworkCore;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<TodosContext>(options => 
				options.UseSqlServer(builder.Configuration.GetConnectionString("TodosContext"))
			);

			builder.Services.AddTransient<ITodosRepository, TodosRepository>();
			builder.Services.AddTransient<ITodosLogic, TodosLogic>();

			builder.Services.AddAutoMapper(typeof(TodosProfile));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
