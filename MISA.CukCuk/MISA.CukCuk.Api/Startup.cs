using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Service;
using MISA.CukCuk.Api.Middware;
using MISA.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk.Api", Version = "v1" });
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();
            services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk.Api v1"));
            }

            // Hook in the global error-handling middleware
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseExceptionHandler(c => c.Run(async context =>
            {

                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                if (exception is CustomerException)
                {
                   
                    var response = new
                    {
                        devMsg = exception.Message,
                        userMsg = "C?? l???i x???y ra vui l??ng li??n h??? MISA",
                        MISACode = "002",
                        Data = "CustomerCode",
                    };
                    var result = JsonConvert.SerializeObject(response);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //var jsonObject = JsonConvert.SerializeObject(My Custom Model);
                    await context.Response.WriteAsJsonAsync(response);
                }
                else
                {
                    var response = new
                    {
                        devMsg = exception.Message,
                        userMsg = "C?? l???i x???y ra vui l??ng li??n h??? MISA",
                        MISACode = "002",
                        Data = exception
                    };
                    await context.Response.WriteAsJsonAsync(response);
                }
                
            }));
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
