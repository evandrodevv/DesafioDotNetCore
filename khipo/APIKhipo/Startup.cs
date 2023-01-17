using APIKhipo.Models;
using APIKhipo.Repository;
using Microsoft.EntityFrameworkCore;
using host = Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;

namespace APIKhipo
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API - Khipo", Version = "v1" });
            });
            
            services.AddDbContext<KHIDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IProductsRepository, ProductsRepository>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, host.IWebHostEnvironment env)
        {
            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Khipo V1");
            });            
        }
    }
}