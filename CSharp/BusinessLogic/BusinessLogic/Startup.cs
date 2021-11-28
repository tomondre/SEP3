using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;
using BusinessLogic.Model.Checkout;
using BusinessLogic.Model.Customers;
using BusinessLogic.Model.Experiences;
using BusinessLogic.Model.Login;
using BusinessLogic.Model.ProductCategory;
using BusinessLogic.Model.Providers;
using BusinessLogic.Networking;
using BusinessLogic.Networking.Customers;
using BusinessLogic.Networking.Experiences;
using BusinessLogic.Networking.Login;
using BusinessLogic.Networking.ProductCategory;
using BusinessLogic.Networking.Providers;
using Grpc.Net.Client;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Networking.Category;
using Networking.Customer;
using Networking.Experience;
using Networking.Login;
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
            var key = @"MIICXgIBAAKBgQDy0/9fpTqf/U49RkU5/49TQi9WB3YzbsxCvKQe22mpWzVUiODW
            1Td3Uuoq7Jkla2qD2o4QIhXk+c7q9nG+8TYxCYBehjmGiHCALuWetYjrPpJ97chP
            uNZYhzBn27+16I/unSqgrFwEKQH79dAOaZtpPmKIq4y1UdIBM7swU5UqeQIDAQAB
            AoGBAM2DUrz2MDm7vn3pfSlq+zhx6XIb+pPpEALjeNuMw05MHUSgW/o2liztBbay
            a6LZ2FojnNxWnMUgD1mYnggGSd9srE7z9CGj+Wk1Ki5zI5IbIFa8G9Nvz1PzQFmo
            rYlomxdb8bb4v4dtaQAnyV5j3Z7mF6VgNzgD3HcVj2sqpu7pAkEA+gvOXImgObZL
            qV2ZN4tUWuANXfzEcRt2tENBnlcDxM0gIiT0q6RVWzcD/x+aoCClKFhNyfUMY6Ud
            81+AEfIRkwJBAPicMWp25D+hSRqTcRvgHmLlgWyo5xU+J9QIXfZC1JRWpgRO3liM
            CdWgvUUirwG0bYBzdukHnsMezAkeRahpy0MCQGJnww8oGqab16sP6vyxGMGq65fR
            on3hERZgYbKvDAynrb3CTYg/ZFhBjpEZHwFl15nJJtQUXIvar67YJs7pNYECQQDp
            lZe4eEysnFWbarzze/gQ46Je/bNg+i1hwxrFrrUdSuxhT9kJSUpUNdqfgp778xKP
            he1LtaUtn1oFlzPLsNsRAkEAh8/TFyrkKk+9RmOHVN/dXATMFtA64keRNwpb3jeX
            1ONCPd9S2/tWcbpJYIOXsJSuiYjBHyE8wKog1Idh7JZiOA==";

            services.AddAuthentication(policy =>
            {
                policy.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                policy.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(policy =>
            {
                policy.RequireHttpsMetadata = false;
                policy.SaveToken = true;
                policy.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSingleton(
                new ProviderService.ProviderServiceClient(
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

            services.AddSingleton(
                new ExperienceService.ExperienceServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
            services.AddSingleton<IExperienceModel, ExperienceModel>();
            services.AddSingleton<IExperienceNet, ExperienceNet>();
            
            services.AddSingleton(
                new LoginService.LoginServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
            services.AddSingleton<ILoginModel>(x => new LoginModel(x.GetRequiredService<ILoginNet>(), key));
            services.AddSingleton<ILoginNet, LoginNet>();
            
            services.AddSingleton<IValidator, Validator>();
            
            services.AddSingleton<ICheckoutModel, CheckoutModel>();
            
            services.AddControllers();
            
            services.AddSingleton<ILinksService, DefaultLinksService>();

            services.AddMemoryCache();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}