using SAF.CasualTimes.Application.Services;
using SAF.CasualTimes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddSAFApplication()
		.AddSAFInfrastructure();
	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}
	app.UseHttpsRedirection();
	app.MapControllers();

	app.Run();
}
