using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using UserManagementApplication.Models;
using Microsoft.OpenApi.Models;

namespace UserManagementApplication
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
            //CORS 설정
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:12345",
                                            "https://www.test.com");
                    });
            });

            services.AddControllers();

            // DB 연결정보
            //DBContext별 DB연결정보세팅
            var dbconnstring = Configuration.GetConnectionString("PostgreSQLConnection");

            // PostgreSQL DbContext 종속성 주입
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(dbconnstring));

            // Swagger 설정
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("myapi", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API Docs",
                    Description = "My API Documentation"
                });
            });
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
                c.SwaggerEndpoint("/swagger/myapi/swagger.json", "My API Docs V1");
            });

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
