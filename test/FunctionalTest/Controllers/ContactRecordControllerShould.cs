using ContactRecord.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Controllers
{
    public class ContactRecordControllerShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ContactRecordControllerShould()
        {
            
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetById_ThrowsGivenInvalidId()
        {
            var invalidId = 0;

            var response = await _client.GetAsync($"/api/v1/ContactRecord/{invalidId}");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
