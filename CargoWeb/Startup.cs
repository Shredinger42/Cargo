using AutoMapper;
using CargoWeb.Configuration;
using CargoWeb.Repositories;
using CargoWeb.Services;
using DevExpress.Xpo.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CargoWeb
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CargoWeb", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationContext>();

            services.AddScoped<ICargoRequestRepository, CargoRequestRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICourierRepository, CourierRepository>();
            services.AddScoped<ICargoRequestService, CargoRequestService>();
            services.AddScoped<ICourierService, CourierService>();
            services.AddScoped<ICourierCargoCargoRequestRepository, CourierCargoCargoRequestRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CargoWeb v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
