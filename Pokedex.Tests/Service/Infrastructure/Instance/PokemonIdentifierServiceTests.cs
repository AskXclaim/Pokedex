using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Pokedex.Service.Infrastructure.Instance;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.InternalModels.PokemonIdentity;
using Pokedex.Service.Models.ReturnedModels.Interfaces;

namespace Pokedex.Tests.Service.Infrastructure.Instance
{
    [TestFixture]
    public class PokemonIdentifierServiceTests
    {
        private Mock<IHttpClientFactory> _clientFactory;

        [SetUp]
        public void Setup()
        {
            _clientFactory = new Mock<IHttpClientFactory>();
        }

        [TestCase(null)]
        [TestCase("https://dummy1.co/api/")]
        [TestCase("https://dummyw.co/api/")]
        public async Task GetPokemonIdentity_WhenCalledSuccessfully_ReturnsAnInstanceOfIPokemonIdentity(string url)
        {
            var pokemonIdentity = new PokemonIdentity(1, "pokemonName", 1, 2);
            _clientFactory.Setup(cf => cf.CreateClient(It.IsAny<string>())).Returns(new HttpClient(new FakeHttpMessageHandler(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(pokemonIdentity), Encoding.UTF8,
                        "application/json")
                })));

            var result = await GetPokemonIdentifierService(url).GetPokemonIdentity("aValidPokemonName");

            Assert.IsInstanceOf<IPokemonIdentity>(result);
            Assert.That(result.Id, Is.EqualTo(pokemonIdentity.Id));
            Assert.That(result.Name, Is.EqualTo(pokemonIdentity.Name));
            Assert.That(result.Height, Is.EqualTo(pokemonIdentity.Height));
            Assert.That(result.Weight, Is.EqualTo(pokemonIdentity.Weight));
        }

        [TestCase(HttpStatusCode.NotFound)]
        [TestCase(HttpStatusCode.BadRequest)]
        [TestCase(HttpStatusCode.BadGateway)]
        public void GetPokemonIdentity_WhenClientCallFails_ThrowsHttpRequestException
            (HttpStatusCode statusCode)
        {
            _clientFactory.Setup(cf => cf.CreateClient(It.IsAny<string>())).Returns(new HttpClient(new FakeHttpMessageHandler(
                new HttpResponseMessage
                {
                    StatusCode = statusCode
                })));

            Assert.ThrowsAsync<HttpRequestException>(() => GetPokemonIdentifierService(null)
                .GetPokemonIdentity("aValidPokemonName"));
        }

        [Test]
        public void GetPokemonIdentity_WhenCalledSuccessfullyButResultIsNull_ThrowsAnException()
        {
            _clientFactory.Setup(cf => cf.CreateClient(It.IsAny<string>())).Returns(new HttpClient(
                new FakeHttpMessageHandler(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8,
                            "application/json")
                    })));

            Assert.ThrowsAsync<Exception>(() => GetPokemonIdentifierService(null)
                .GetPokemonIdentity("aValidPokemonName"));
        }

        private IPokemonIdentifierService GetPokemonIdentifierService(string url) => string.IsNullOrWhiteSpace(url)
            ? new PokemonIdentifierService(_clientFactory.Object)
            : new PokemonIdentifierService(_clientFactory.Object, url);
    }
}