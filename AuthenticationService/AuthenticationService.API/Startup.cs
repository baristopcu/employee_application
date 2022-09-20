using AuthenticationService.Business.Interfaces;
using AuthenticationService.Business.Repositories;
using AuthenticationService.Business.Services;
using AuthenticationService.Data.Context;
using AuthenticationService.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthenticationService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEntityFrameworkMySql();


            // Replace with your connection string.
            var connectionString = Configuration.GetValue<string>("ConnectionString");
            services.AddDbContextPool<AuthenticationContext>(options => options
                .UseMySql(connectionString)
            );



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Authentication Service", Version = "v1" });
            });


            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();

            var secretKey = Configuration.GetValue<string>("SecretKey");
            services.AddScoped<IUserService>(provider => new UserService(provider.GetService<IGenericRepository<User>>(), secretKey));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication Service v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

