using AutoMapper;
using LibraryWda.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;

namespace LibraryWda.API
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

         
            services.AddDbContext<DataContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddControllersWithViews().AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = 
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddVersionedApiExplorer(options =>
           {
               options.GroupNameFormat = "'v'VVV";
               options.SubstituteApiVersionInUrl = true;
           })
           .AddApiVersioning(options =>
              {
                  options.AssumeDefaultVersionWhenUnspecified = true;
                  options.DefaultApiVersion = new ApiVersion(1, 0);
                  options.ReportApiVersions = true;
              });

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options => {

                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                            description.GroupName,
                            new Microsoft.OpenApi.Models.OpenApiInfo()
                            {
                                Title = "LibraryWda API",
                                Version = description.ApiVersion.ToString(),
                                TermsOfService = new Uri("https://seustermosdeuso.com"),
                                Description = "Service created with the aim of studying Asp .Net Core + EF Core + Docker, a simple API for managing a book loan from a library",
                                License = new Microsoft.OpenApi.Models.OpenApiLicense
                                {
                                    Name = "LibraryWDA License",
                                    Url = new Uri("https://mit.com"),
                                },
                                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                                {
                                    Name = "Maurycio Kemesson",
                                    Email = "mauriciokemesson@gmail.com",
                                    Url = new Uri("https://github.com/Maurycio-Kemesson"),
                                }
                            }
                        );
                }
                        

                var xlmCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xlmCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xlmCommentsFile);

                options.IncludeXmlComments(xlmCommentsFullPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IWebHostEnvironment env,
                                IApiVersionDescriptionProvider apiProviderDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    foreach (var descriptions in apiProviderDescription.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{descriptions.GroupName}/swagger.json", 
                            descriptions.GroupName.ToUpperInvariant()
                        );
                    }
                    options.RoutePrefix = "";
                });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
