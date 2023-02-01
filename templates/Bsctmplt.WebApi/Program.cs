using Bsctmplt.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ProgramUtils.PrepareServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
