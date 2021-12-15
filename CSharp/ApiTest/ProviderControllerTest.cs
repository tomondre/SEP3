using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BusinessLogic.Controllers;
using BusinessLogic.Model.Providers;
using BusinessLogic.Models;
using BusinessLogic.Models.Orders;
using FakeItEasy;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;
using Xunit;

namespace ApiTest
{
    public class ProviderControllerTest
    {
        [Fact]
        public async void GetProvidersAsync()
        {
            //Arrange
            var fakeModel = A.Fake<IProviderModel>();
            A
                .CallTo(() =>  fakeModel.GetAllProvidersAsync(1))
                .Returns(
                    Task.FromResult(new Page<ProviderList>()
                    {
                        Content = new ProviderList()
                        {
                            Providers = new List<Provider>()
                            {
                                new Provider(),
                                new Provider(),
                                new Provider(),
                                new Provider(),
                                new Provider()
                            },
                            
                        }
                    }));
            var fakeLinksService = A.Fake<ILinksService>();
            var controller = new ProviderController(fakeLinksService, fakeModel);
            
            //Act
            var result = await controller.GetProvidersAsync(true, "", 1);
            
            //Assert
            var list = (Page<ProviderList>) ((ObjectResult) result.Result).Value;
            Assert.Equal(5, list.Content.Providers.Count);
        }
        
        [Fact]
        public async void GetProviderById()
        {
            //Arrange
            var fakeModel = A.Fake<IProviderModel>();
            A
                .CallTo(() => fakeModel.GetProviderByIdAsync(A<int>.Ignored))
                .Returns(Task.FromResult(new Provider()));
            var fakeLinksService = A.Fake<ILinksService>();
            var controller = new ProviderController(fakeLinksService, fakeModel);
            
            //Act
            var result = await controller.GetProviderById(1);
            var response = ((ObjectResult) result.Result);
            var provider = (Provider) response.Value;
            var statusCode = response.StatusCode;

            //Assert
            Assert.NotNull(provider);
            Assert.Equal(200, statusCode);
        }
        
        
        [Fact]
        public async void GetProviderByIdNotFound()
        {
            //Arrange
            var fakeModel = A.Fake<IProviderModel>();
            A
                .CallTo(() => fakeModel.GetProviderByIdAsync(A<int>.Ignored))
                .Throws(new Exception("error"));
            var fakeLinksService = A.Fake<ILinksService>();
            var controller = new ProviderController(fakeLinksService, fakeModel);
            
            //Act
            var result = await controller.GetProviderById(1);
            var response = (ObjectResult) result.Result;
            var responseValue = (string) response.Value;
            var statusCode = response.StatusCode;
            
            //Assert
            Assert.NotNull(responseValue);
            Assert.Equal(403, statusCode);
        }
        
        
        
    }
}