using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Pokedex.Application.Infrastructure.Instances;
using Pokedex.Application.Models.Interfaces;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.ReturnedModels.Instances;

namespace Pokedex.Tests.Application.Infrastructure.Instances
{
    [TestFixture]
    public class PokemonDetailRepositoryTests
    {
        private Mock<IPokemonDetailService> _detailService;

        [SetUp]
        public void Setup()
        {
            _detailService = new Mock<IPokemonDetailService>();
        }

        [Test]
        public void PokemonDetailRepository_WhenInstantiatedWithAnInvalidIPokemonDetailService_ThrowsAnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPokemonDetailRepository(null));
        }

        private PokemonDetailRepository GetPokemonDetailRepository(IPokemonDetailService detailService) =>
        new PokemonDetailRepository(detailService);

        [Test]
        public async Task GetBasicPokemonDetails_WhenCalledSuccessFully_ReturnsAnInstanceOfIPokemonDetailWithErrorPropertyNotSet()
        {
            var details = GetPokemonDetail();
            _detailService.Setup(ds => ds.GetBasicPokemonDetails(It.IsAny<string>())).ReturnsAsync(details);

            var result = await GetPokemonDetailRepository(_detailService.Object).GetBasicPokemonDetails("pokemonName");

            VerifyBasicRequirement(result, true);
            VerifyProperties(result, details);
        }

        [Test]
        public async Task GetBasicPokemonDetails_WhenCalledAndAnExceptionOccurs_ReturnsAnInstanceOfIPokemonDetailWithErrorPropertySet()
        {
            _detailService.Setup(ds => ds.GetBasicPokemonDetails(It.IsAny<string>())).ThrowsAsync(GetException());

            var result = await GetPokemonDetailRepository(_detailService.Object).GetBasicPokemonDetails("pokemonName");

            VerifyBasicRequirement(result, false);
            VerifyProperties(result);
        }

        [Test]
        public async Task GetTranslatedPokemonDetails_WhenCalledSuccessFully_ReturnsAnInstanceOfIPokemonDetailWithErrorPropertyNotSet()
        {
            var details = GetPokemonDetail();
            _detailService.Setup(ds => ds.GetTranslatedPokemonDetails(It.IsAny<string>())).ReturnsAsync(details);

            var result = await GetPokemonDetailRepository(_detailService.Object).GetTranslatedPokemonDetails("pokemonName");

            VerifyBasicRequirement(result, true);
            VerifyProperties(result, details);
        }

        [Test]
        public async Task GetTranslatedPokemonDetails_WhenCalledAndAnExceptionOccurs_ReturnsAnInstanceOfIPokemonDetailWithErrorPropertySet()
        {
            _detailService.Setup(ds => ds.GetTranslatedPokemonDetails(It.IsAny<string>())).ThrowsAsync(GetException());

            var result = await GetPokemonDetailRepository(_detailService.Object).GetTranslatedPokemonDetails("pokemonName");

            VerifyBasicRequirement(result, false);
            VerifyProperties(result);
        }

        private void VerifyBasicRequirement(IPokemonDetail result, bool expectedResult)
        {
            Assert.IsInstanceOf<IPokemonDetail>(result);
            Assert.That(string.IsNullOrWhiteSpace(result.Error), Is.EqualTo(expectedResult));
        }

        private void VerifyProperties(IPokemonDetail result, Pokedex.Service.Models.ReturnedModels.Interfaces.IPokemonDetail details)
        {
            Assert.That(result.Name, Is.EqualTo(details.Name));
            Assert.That(result.Description, Is.EqualTo(details.Description));
            Assert.That(result.Habitat, Is.EqualTo(details.Habitat));
            Assert.That(result.IsLegendary, Is.EqualTo(details.IsLegendary));
            Assert.That(result.Height, Is.EqualTo(details.Height));
            Assert.That(result.Weight, Is.EqualTo(details.Weight));
            Assert.That(result.IsBaby, Is.EqualTo(details.IsBaby));
            Assert.That(result.IsMythical, Is.EqualTo(details.IsMythical));
            Assert.That(result.Information, Is.EqualTo(details.Information));
            Assert.That(result.HasError, Is.False);
        }

        private void VerifyProperties(IPokemonDetail result)
        {
            const string empty = "";
            Assert.That(result.Name, Is.EqualTo(empty));
            Assert.That(result.Description, Is.EqualTo(empty));
            Assert.That(result.Habitat, Is.EqualTo(empty));
            Assert.That(result.IsLegendary, Is.EqualTo(null));
            Assert.That(result.Height, Is.EqualTo(null));
            Assert.That(result.Weight, Is.EqualTo(null));
            Assert.That(result.IsBaby, Is.EqualTo(null));
            Assert.That(result.IsMythical, Is.EqualTo(null));
            Assert.That(result.Information, Is.EqualTo(empty));
            Assert.That(result.HasError, Is.True);
        }

        private Exception GetException() => new Exception("An error occurred");

        private Pokedex.Service.Models.ReturnedModels.Interfaces.IPokemonDetail GetPokemonDetail() => new PokemonDetail(1,
                "pokemonName", "description", "habitat", true, 1, 1, "shape", false, false, "information");
    }
}