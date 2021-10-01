using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestProject
{
    public class IntegrationTest1 : IClassFixture<WebApplicationFactory<BlazorApp.Startup>>
    {
        private readonly WebApplicationFactory<BlazorApp.Startup> _factory;
        private readonly ITestOutputHelper _testOutputHelper;

        public IntegrationTest1(WebApplicationFactory<BlazorApp.Startup> factory, ITestOutputHelper testOutputHelper)
        {
            _factory = factory;
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/counter")]
        [InlineData("/fetchdata")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContent(String path)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(path);

            // Assert
            _testOutputHelper.WriteLine($"Response code: {response.StatusCode.ToString()}");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}