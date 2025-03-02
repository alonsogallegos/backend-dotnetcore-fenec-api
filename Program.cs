
using FenecApi.Extensions;
using FenecApi.Mapping;

namespace FenecApi;
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Configure Logging (NLog)
		builder.ConfigureLogging();

		// Add services to the container.
		// Configure Services ==>
		builder.Services.ConfigureDbContext(builder.Configuration);
		builder.Services.ConfigureDependencies();
		builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		// Configure Middlewares ==>
		app.ConfigureMiddlewares();


		app.MapControllers();

		app.Run();
	}
}

