using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmailService.Db;
using EmailService.Db.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using EmailServiceWebApi.Models;

namespace EmailServiceWebApi
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile(AppContext.BaseDirectory + "configurationEmailServer.json");
            AppConfiguration = builder.Build();
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("email_service");

            // создание объекта ConfigureEmailServer по ключам из конфигурации
            services.Configure<ConfigureEmailServer>(AppConfiguration);

            services.AddControllers();
            services.AddMvc();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));
            services.AddTransient<EmailSender>();
            services.AddTransient<IMailsRepository, MailsDbRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
