﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RectorsBlogAPI.Data;

namespace RectorsBlogAPI.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var services = app.ApplicationServices.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();

                dbContext.Database.Migrate();
            }
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My RectorsBlog API");
                    options.RoutePrefix = string.Empty;
                });

    }
}
