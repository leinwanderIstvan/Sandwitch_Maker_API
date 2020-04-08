using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAPI.Data;
using FoodAPI.Repository;
using FoodAPI.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using FoodAPI.Mapper;
using System.Reflection;
using System.IO;

namespace FoodAPI
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISandwitchRepository, SandwitchRepository>();
            services.AddAutoMapper(typeof(SandwitchMappings));
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("SandwitchOpenApiSpec", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "FoodMaker API",
                    Version = "1"
                });

                var xmlCommnetFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var cmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommnetFile);
                options.IncludeXmlComments(cmlCommentFullPath);


            }); 
            services.AddControllers();
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
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/SandwitchOpenApiSpec/swagger.json", "FoodMaker API");
                options.RoutePrefix = "";

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
