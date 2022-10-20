using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Endpoint
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<F1DbContext>();

            services.AddTransient<IRepository<TeamPrincipals>, TeamPrincipalRepository>();
            services.AddTransient<IRepository<Teams>, TeamRepository>();
            services.AddTransient<IRepository<Drivers>, DriverRepository>();

            services.AddTransient<ITeamPrincipal, TeamPrincipalLogic>();
            services.AddTransient<ITeam, TeamLogic>();
            services.AddTransient<IDriver, DriverLogic>();

            services.AddControllers();
            services.AddSwaggerGen(t => t.SwaggerDoc("V1", new OpenApiInfo
            { Title = "BJJ9B1_HFT_2022231.Endpoint", Version = "V1" })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(t => t.SwaggerEndpoint("/swagger/v1/swagger.json", "BJJ9B1_HFT_2022231.Endpoint V11"));
            }

            app.UseExceptionHandler(t => t.Run(async context =>
            {
                var exc = context.Features
                .Get<IExceptionHandlerFeature>()
                .Error;
                var msg = new { Msg = exc.Message };
                await context.Response.WriteAsJsonAsync(msg);
            }
            ));

            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    endpoints.MapControllers();
                });
            });
        }
    }
}
