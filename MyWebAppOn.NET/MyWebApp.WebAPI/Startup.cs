using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWebApp.BLL.Contracts;
using MyWebApp.BLL.Implementation;
using MyWebApp.DAL;
using MyWebApp.DAL.Contracts;
using MyWebApp.DAL.Implementations;

namespace MyWebApp.WebAPI
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст MobileContext в качестве сервиса в приложение
            services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddControllersWithViews();
            
            services.AddAutoMapper(typeof(Startup));
            
            //BLL
            services.Add(new ServiceDescriptor(typeof(ICollectionService), typeof(CollectionService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IByerService), typeof(ByerService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IOwnerService), typeof(OwnerService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPictureService), typeof(PictureService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteService), typeof(NoteService), ServiceLifetime.Scoped));
            
            // DAL
            services.Add(new ServiceDescriptor(typeof(ICollectionDAL), typeof(CollectionDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IByerDAL), typeof(ByerDAL), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IOwnerDAL), typeof(OwnerDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPictureDAL), typeof(PictureDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteDAL), typeof(NoteDAL), ServiceLifetime.Scoped));

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}