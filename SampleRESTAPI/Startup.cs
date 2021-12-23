using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SampleRESTAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI
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
            // Dependency Inject Containers

            // Injecting the Controllers
            services.AddScoped<IStudent, StudentDAL>();
            services.AddScoped<ICourse, CourseDAL>();
            services.AddScoped<IEnrollment, EnrollmentDAL>();


            //Joining must incliude this services. Optional Solution 1
            //services.AddJsonOptions(x => x.JsonSerializerOptions.Referencehandler = )

            //Solution 2 Instal 
            // Microsoft.AspNetCore.Mvc.NewtonsoftJson
            // Penjelasan : ????? Reference Loop handing nya di Ignore sehingga isi nya tidak di tampilkan (Isi data yang sama)
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                //Add XMl : Content Negotiation
                .AddXmlSerializerFormatters();



            // Add Data Migration Services from || Data > ApplicationDbContext.cs
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));


            //Add Auto Mapper for Mapping the DTO
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add XML Extension selain JSON
            services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SampleWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
