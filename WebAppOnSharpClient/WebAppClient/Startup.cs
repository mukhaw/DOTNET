using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppClient.Services.Contracts;
using WebAppClient.Services.Implementations;

namespace WebAppClient
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
            services.AddControllersWithViews();
            
            services.AddHttpClient<IDoctorService, DoctorService>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IDiseaseService, DiseaseService>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IPatientService, PatientService>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IDoctorService, DoctorService>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<IStreetService, StreetService>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
            services.AddHttpClient<INoteService, NoteService>(client =>
            {
                client.BaseAddress = new Uri(this.Configuration.GetSection("ApiOptions")["Url"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Doctor}/{action=List}"
                    );
            });
        }
    }
}