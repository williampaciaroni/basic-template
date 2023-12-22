using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Bsctmplt.EntityFrameworkCore;
using Bsctmplt.Repository;
using Bsctmplt.EntityFramework.Repository;

namespace Bsctmplt.WebApi
{
	public class ProgramUtils
	{
		public static void PrepareServices(WebApplicationBuilder builder)
		{
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterDB(builder);
            RegisterDependency(builder);
            RegisterRepositories(builder);
        }

        private static void RegisterDB(WebApplicationBuilder builder)
        {
            BsctmpltDbContextFactory.SetConfiguration(builder.Configuration);
            builder.Services.AddDbContext<BsctmpltDbContext>();
        }

        private static void RegisterDependency(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        }

        private static void RegisterRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ISampleRepository, SampleRepository>();
        }
    }
}

