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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("email_service");

            // создание объекта ConfigureEmailServer по ключам из конфигурации
            services.Configure<ConfigureEmailServer>(Configuration);

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
