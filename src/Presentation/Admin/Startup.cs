using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using AutoMapper;

using TinyShoppingCart.Infrastructure.Persistence;
using TinyShoppingCart.Domain.UnitOfWork;
using TinyShoppingCart.Infrastructure.Persistence.UnitOfWork;
using TinyShoppingCart.Domain.Repositories;
using TinyShoppingCart.Infrastructure.Persistence.Repositories;
using DataTables.AspNet.AspNetCore;

namespace TinyShoppingCart.Presentation.Admin
{
    public class Startup
    {
        IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TinyShoppingCartDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("TinyShoppingCartConnection"), 
                                        ob => {
                                            ob.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.FullName);
                                            ob.UseRowNumberForPaging();
                                        }
                                    );
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddAutoMapper();

            services.AddMvc();

            services.RegisterDataTables();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Default", 
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
