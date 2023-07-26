using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongodbData.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;



namespace MongodbData
{


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDBSettings"));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var mongoDBSettings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
                return new MongoClient(mongoDBSettings.ConnectionString);
            });
            services.AddScoped<DriverContext>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("6.5.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MongodbData", Version = "6.0" });

            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });



            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/6.5.0/swagger.json", "MongodbData 6.0");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
