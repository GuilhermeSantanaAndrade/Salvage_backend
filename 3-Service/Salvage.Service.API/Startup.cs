using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging; 
using Salvage.Infra.CrossCutting.IoC; 

namespace Salvage.Service.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(opcoes => opcoes.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddMvc();
            services.AddAutoMapper();

            services.AddSwaggerGen(opcoes =>
            {
                opcoes.DescribeAllEnumsAsStrings(); 
                opcoes.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Salvage API", Version = "V1" });
            });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AllowAll");

            loggerFactory.AddConsole() ;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(ui => {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Salvage API V1");
            });
        }
        private static void RegisterServices(IServiceCollection services)
        { 
            InjetorNativo.RegisterServices(services);
        }
    }
}
