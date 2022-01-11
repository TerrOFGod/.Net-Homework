using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DB.EF;
using DB.Interface;
using DB.Services;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
            =>services.AddDbContext<ApplicationContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                    .UseValidationCheckConstraints())
                .AddScoped<IEnemyRepo, EnemyRepo>()
                .AddSwaggerGen(c => c.SwaggerDoc("v1", 
                    new OpenApiInfo { Title = "DB", Version = "v1"}))
                .AddControllers();
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DB v1"));
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
