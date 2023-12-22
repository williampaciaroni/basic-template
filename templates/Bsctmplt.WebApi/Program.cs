using Bsctmplt.EntityFrameworkCore;
using Bsctmplt.WebApi;
using Microsoft.EntityFrameworkCore;

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

using (var scope = app.Services.CreateScope())
{
    using var context = scope.ServiceProvider.GetService<BsctmpltDbContext>();
    ArgumentNullException.ThrowIfNull(context);
    context.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
