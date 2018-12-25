using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentimentAnalysisWithNETCoreExample.Data;
using SentimentAnalysisWithNETCoreExample.Services;
using SentimentAnalysisWithNETCoreExample.Services.Implementations;

namespace SentimentAnalysisWithNETCoreExample
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpClient("TextAnalyticsAPI", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("TextAnalyticsAPIBaseAddress"));
                c.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Configuration.GetValue<string>("TextAnalyticsAPIKey"));
            });

            //Services
            services.AddTransient<ITextAnalyticsService, TextAnalyticsService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCommentService, ProductCommentService>();

            //Data
            services.AddDbContext<ProductDBContext>(option => option.UseInMemoryDatabase("ProductDBContext"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProductDBContext>();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}