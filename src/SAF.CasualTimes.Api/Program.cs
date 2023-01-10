using Microsoft.AspNetCore.Mvc.Infrastructure;
using SAF.CasualTimes.Api.Common.Errors;
using SAF.CasualTimes.Application.Services;
using SAF.CasualTimes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddSAFApplication()
		.AddSAFInfrastructure(builder.Configuration);
	builder.Services.AddControllers();
	builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
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
	app.UseExceptionHandler("/error");
	app.MapControllers();
}

app.Run();