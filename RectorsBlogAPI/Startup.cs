using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RectorsBlogAPI.Infrastructure.Extensions;

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

            app
            .UseSwaggerUI()
            .UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed((host) => true))
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseStaticFiles()
            .UseMvc()
            .ApplyMigrations();
        }
    }
}
