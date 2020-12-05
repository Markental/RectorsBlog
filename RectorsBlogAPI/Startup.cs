using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RectorsBlogAPI.Infrastructure.Extensions;
using RectorsBlogAPI.Infrastructure.Filters;

namespace RectorsBlogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddCors()
                .AddDatabase(Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(Configuration))
                .AddApplicationServices()
                .AddSwagger()
                
                .AddApiMvc(); 
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            // global cors policy
            app
            .UseSwaggerUI()
            .UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseStaticFiles()
            .UseMvc()
            .ApplyMigrations();
        }
    }
}
