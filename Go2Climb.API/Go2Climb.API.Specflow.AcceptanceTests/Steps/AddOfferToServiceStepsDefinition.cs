using System.Net;
using System.Net.Mime;
using System.Text;
using Go2Climb.API.Agencies.Resources;
using Go2Climb.API.Resources;
using Go2Climb.API.Services.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;

namespace Go2Climb.API.Specflow.AcceptanceTests.Steps;

[Binding]
    public class AddOfferToServiceStepsDefinition
    {

        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private AgencyResource Agency { get; set; }
        private ServiceResource Service { get; set; }

        public AddOfferToServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/services/(.*) is available")]
        public void GivenTheEndpointHttpsLocalhostApiVServicesIsAvailable(int port, int version,int id)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A agency is already stored")]
        public async void GivenAAgencyIsAlreadyStored(Table existingAgencyResource)
        {
            var agencyUri = new Uri("https://localhost:5001/api/v1/agencies");
            var resource = existingAgencyResource.CreateSet<SaveAgencyResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var agencyResponse = Client.PostAsync(agencyUri, content);
            var agencyResponseData = await agencyResponse.Result.Content.ReadAsStringAsync();
            var existingAgency = JsonConvert.DeserializeObject<AgencyResource>(agencyResponseData);
            Agency = existingAgency;
        }

        [Given(@"A Service is already stored")]
        public async void GivenAServiceIsAlreadyStored(Table existingServiceResource)
        {
            var serviceUri = new Uri("https://localhost:5001/api/v1/services");
            var resource = existingServiceResource.CreateSet<SaveServiceResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var serviceResponse = Client.PostAsync(serviceUri, content);
        }

        [When(@"A Service Request is Sent with complete information for a upgrade of price")]
        public void WhenAServiceRequestIsSentWithCompleteInformationForAUpgradeOfPrice(Table saveServiceResource)
        {
            var resource = saveServiceResource.CreateSet<SaveServiceResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PutAsync("https://localhost:5001/api/v1/services/1", content);
        }

        [Then(@"A response with status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.AreEqual(actualStatusCode, actualStatusCode);
        }
    }