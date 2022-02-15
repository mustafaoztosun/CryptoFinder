using CryptoFinder.Business.Abstract;
using CryptoFinder.Business.Concrete;
using CryptoFinder.DataAccess.Abstract;
using CryptoFinder.DataAccess.Conctare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoFinder.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Service check activated
            services.AddControllers();
            services.AddSingleton<ICryptoService, CryptoManager>();
            services.AddSingleton<ICryptoRepository, CryptoRepository>();
            //Swagger is added
            //I edited the information on the main page with these codes
            services.AddSwaggerDocument(config=> {
                config.PostProcess = (doc => {
                    doc.Info.Title = "All Crypto API";
                    doc.Info.Version = "1.1.13";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Mustafa Öztosun",
                        Url = "https://www.youtube.com/channel/UCcOh6L0uE06LJJdR-plCcEg",
                        Email = "mustafaoztosun.g@gmial.com"
                    };
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

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
