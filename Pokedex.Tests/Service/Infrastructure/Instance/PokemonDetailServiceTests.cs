using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Pokedex.Service.Infrastructure.Instance;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.InternalModels.PokemonDetail;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Tests.Service.Infrastructure.Instance
{
    [TestFixture]
    public class PokemonDetailServiceTests
    {
        private Mock<IHttpClientFactory> _clientFactory;
        private Mock<IPokemonIdentifierService> _identityService;

        private IConfiguration Configuration()
        {
            string projectPath = AppDomain.CurrentDomain?.BaseDirectory?.Split(new[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [SetUp]
        public void Setup()
        {
            _clientFactory = new Mock<IHttpClientFactory>();
            _identityService = new Mock<IPokemonIdentifierService>();
        }

        [TestCase(null)]
        [TestCase("https://dummy1.co/api/")]
        public async Task GetBasicPokemonDetails_WhenCalledSuccessfully_ReturnsAnInstanceOfIPokemonDetail(string url)
        {
            var pokemonDetail = GetPokemonDetail();
            var value = JsonConvert.SerializeObject(pokemonDetail);
            _identityService.Setup(i => i.GetPokemonIdentity(It.IsAny<string>())).ReturnsAsync(PokemonIdentity);
            _clientFactory.Setup(cf => cf.CreateClient(It.IsAny<string>())).Returns(new HttpClient(new FakeHttpMessageHandler(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(value, Encoding.UTF8, "application/json")
                })));

            var result = await GetPokemonDetailService(url).GetBasicPokemonDetails("aValidPokemonName");

            Assert.IsInstanceOf<IPokemonDetail>(result);
            Assert.That(result.Id, Is.EqualTo(pokemonDetail.Id));
            Assert.That(result.Name, Is.EqualTo(pokemonDetail.Name));
            Assert.That(string.IsNullOrWhiteSpace(result.Description), Is.EqualTo(false));
            Assert.That(result.Habitat, Is.EqualTo(pokemonDetail.Habitat.Name));
            Assert.That(result.Shape, Is.EqualTo(pokemonDetail.Shape.Name));
            Assert.That(result.IsLegendary, Is.EqualTo(pokemonDetail.IsLegendary));
            Assert.That(result.IsBaby, Is.EqualTo(pokemonDetail.IsBaby));
            Assert.That(result.IsMythical, Is.EqualTo(pokemonDetail.IsMythical));
        }

        private Pokedex.Service.Models.ReturnedModels.Instances.PokemonIdentity PokemonIdentity =>
            new Pokedex.Service.Models.ReturnedModels.Instances.PokemonIdentity(1, "pokemonName", 1, 2);

        private Pokedex.Service.Models.InternalModels.PokemonDetail.Interfaces.IPokemonDetail GetPokemonDetail()
        {
            return new PokemonDetail(1, "pokemonName", FlavorTextEntries, Habitat, true, Shape, false, false);
        }

        private Shape Shape => new Shape() { Name = "shape" };

        private Habitat Habitat => new Habitat() { Name = "habitat" };

        private FlavorTextEntries[] FlavorTextEntries => new FlavorTextEntries[]
            {
                new FlavorTextEntries()
                    { FlavorText = "description \\n",Language = new Language(){Name = "en"}},
                new FlavorTextEntries()
                    { FlavorText = "こんにちは",Language = new Language(){Name = "jp"}}
            };

        //[TestCase(HttpStatusCode.NotFound)]
        //[TestCase(HttpStatusCode.BadRequest)]
        //[TestCase(HttpStatusCode.BadGateway)]
        //public void GetPokemonIdentity_WhenClientCallFails_ThrowsHttpRequestException
        //    (HttpStatusCode statusCode)
        //{
        //    _clientFactory.Setup(cf => cf.CreateClient(It.IsAny<string>())).Returns(new HttpClient(new FakeHttpMessageHandler(
        //        new HttpResponseMessage
        //        {
        //            StatusCode = statusCode
        //        })));

        //    Assert.ThrowsAsync<HttpRequestException>(() => GetPokemonDetailService(null)
        //        .GetPokemonIdentity("aValidPokemonName"));
        //}

        //[Test]
        //public void GetPokemonIdentity_WhenCalledSuccessfullyButResultIsNull_ThrowsAnException()
        //{
        //    _clientFactory.Setup(cf => cf.CreateClient(It.IsAny<string>())).Returns(new HttpClient(
        //        new FakeHttpMessageHandler(
        //            new HttpResponseMessage
        //            {
        //                StatusCode = HttpStatusCode.OK,
        //                Content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8,
        //                    "application/json")
        //            })));

        //    Assert.ThrowsAsync<Exception>(() => GetPokemonDetailService(null)
        //        .GetPokemonIdentity("aValidPokemonName"));
        //}

        private IPokemonDetailService GetPokemonDetailService(string url) => string.IsNullOrWhiteSpace(url)
            ? new PokemonDetailService(_clientFactory.Object, _identityService.Object, Configuration())
            : new PokemonDetailService(_clientFactory.Object, _identityService.Object, Configuration(), url);
    }
}