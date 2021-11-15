using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Model;
using BusinessLogic.Model.Customers;
using BusinessLogic.Model.ProductCategory;
using BusinessLogic.Networking;
using BusinessLogic.Networking.Customers;
using BusinessLogic.Networking.ProductCategory;
using Grpc.Net.Client;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Networking.Category;
using Networking.Customers;
using Networking.Provider;
using RiskFirst.Hateoas;

namespace BusinessLogic
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
            services.AddSingleton(
                new ProtobufProviderService.ProtobufProviderServiceClient(
                    GrpcChannel.ForAddress("http://localhost:9090")));          
            services.AddSingleton<IProviderModel, ProviderModel>();
            services.AddSingleton<IProviderNet, ProviderNet>();
            
            services.AddSingleton(
                new CategoryService.CategoryServiceClient(
                    GrpcChannel.ForAddress("http://localhost:9090")));
            services.AddSingleton<IProductCategoryModel, ProductCategoryModel>();
            services.AddSingleton<IProductCategoryNet, ProductCategoryNet>();
            
            services.AddSingleton(
                new CustomerService.CustomerServiceClient(
                    GrpcChannel.ForAddress("http://localhost:9090")));
            services.AddSingleton<ICustomerModel, CustomerModel>();
            services.AddSingleton<ICustomerNet, CustomerNet>();
            
            services.AddControllers();
            
            services.AddSingleton<ILinksService, DefaultLinksService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BusinessLogic", Version = "v1"});
            });
            services.AddLinks(config =>
            {
                config.AddPolicy<Provider>(policy =>
                {
                    policy
                        .RequireRoutedLink("self", "GetProviderByIdRoute", x => new {id = x.Id})
                        .RequireRoutedLink("edit", "EditProviderRoute", x => new {id = x.Id})
                        .RequireRoutedLink("remove", "DeleteProviderRoute", x => new {id = x.Id});
                });
                config.AddPolicy<ProviderList>(policy =>
                {
                    policy.RequireRoutedLink("self", "GetProvidersRoute");
                    policy.RequireRoutedLink("create", "CreateProviderRoute");
                });
                config.AddPolicy<HandShake>(policy =>
                {
                    policy.RequireRoutedLink("allProviders", "GetProvidersRoute");
                });
                //TODO add self rel
                config.AddPolicy<Category>(policy =>
                {
                    policy.RequireRoutedLink("edit", "EditCategoryRoute", x => new {id = x.Id})
                        .RequireRoutedLink("remove", "DeleteCategoryRoute", x => new {id = x.Id});
                });
                config.AddPolicy<CategoryList>(policy =>
                {
                    policy.RequireSelfLink();
                    policy.RequireRoutedLink("create", "CreateCategoryRoute");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusinessLogic v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}