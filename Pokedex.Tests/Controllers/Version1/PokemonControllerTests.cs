using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Controllers;
using Pokedex.Controllers.Version1;
using Pokedex.Mapping;
using Pokedex.Models.Instances;
using Pokedex.Models.Interfaces;
using PokemonModel = Pokedex.Application.Models.Instances.PokemonModel;

namespace Pokedex.Tests.Controllers.Version1
{
    [TestFixture]
    public class PokemonControllerTests
    {
        private Mock<IPokemonDetailRepository> _detailRepository;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _detailRepository = new Mock<IPokemonDetailRepository>();
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            _mapper = new Mapper(config);
        }

        [TestCase("poke-name", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("poke_name", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("フシギダネ", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("", Constants.PokemonNameRequired)]
        [TestCase(null, Constants.PokemonNameRequired)]
        public async Task GetPokemon_WhenCalledWithAnInvalidPokemonName_ReturnsBadRequest(string pokemonName, string expectedResult)
        {
            var actionResult = await GetPokemonController().GetPokemon(pokemonName);

            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;

            VerifyInvalidPokemonName(result, expectedResult);
        }

        [TestCase("poke-name", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("poke_name", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("フシギダネ", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("", Constants.PokemonNameRequired)]
        [TestCase(null, Constants.PokemonNameRequired)]
        public async Task GetTranslatedPokemon_WhenCalledWithAnInvalidPokemonName_ReturnsBadRequest
            (string pokemonName, string expectedResult)
        {
            var actionResult = await GetPokemonController().GetTranslatedPokemon(pokemonName);

            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;
            VerifyInvalidPokemonName(result, expectedResult);
        }

        private void VerifyInvalidPokemonName(BadRequestObjectResult result, string expectedResult)
        {
            var modelState = result?.Value as SerializableError;
            var value = modelState?.Values.ToList().First() as string[];
            Assert.That(value?[0], Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task GetPokemon_WhenErrorPresentInResult_ReturnsNotFound()
        {
            var pokemonName = "PokemonName ";
            _detailRepository.Setup(dr => dr.GetBasicPokemonDetails(It.Is<string>(
                s => s.Equals(pokemonName.Trim().ToLower())))).ReturnsAsync(GetPokemonModel());

            var actionResult = await GetPokemonController().GetPokemon(pokemonName);

            Assert.IsInstanceOf<NotFoundObjectResult>(actionResult.Result);
            var result = actionResult.Result as NotFoundObjectResult;
            VerifyNotFoundResult(result);
        }

        [Test]
        public async Task GetTranslatedPokemon_WhenErrorPresentInResult_ReturnsNotFound()
        {
            var pokemonName = "PokemonName ";
            _detailRepository.Setup(dr => dr.GetTranslatedPokemonDetails(It.Is<string>(
                s => s.Equals(pokemonName.Trim().ToLower())))).ReturnsAsync(GetPokemonModel());

            var actionResult = await GetPokemonController().GetTranslatedPokemon(pokemonName);

            Assert.IsInstanceOf<NotFoundObjectResult>(actionResult.Result);
            var result = actionResult.Result as NotFoundObjectResult;
            VerifyNotFoundResult(result);
        }

        private void VerifyNotFoundResult(NotFoundObjectResult result)
        {
            var value = result?.Value as string;
            Assert.That(string.IsNullOrWhiteSpace(value), Is.False);
        }

        [Test]
        public async Task GetPokemon_WhenCalledSuccessfully_ReturnsOk()
        {
            _detailRepository.Setup(dr => dr.GetBasicPokemonDetails(
                It.IsAny<string>())).ReturnsAsync(SuccessPokemonDetail);

            var actionResult = await GetPokemonController().GetPokemon("pokemonName");

            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.IsInstanceOf<IPokemonDetail>(result?.Value);
            var pokemonDetail = result?.Value as Models.Instances.PokemonModel;
            VerifyDetailsOfSuccessfulCall(pokemonDetail, SuccessPokemonDetail);
        }

        [Test]
        public async Task GetTranslatedPokemon_WhenCalledSuccessfully_ReturnsOk()
        {
            _detailRepository.Setup(dr => dr.GetTranslatedPokemonDetails(
                It.IsAny<string>())).ReturnsAsync(SuccessPokemonDetail);

            var actionResult = await GetPokemonController().GetTranslatedPokemon("pokemonName");

            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.IsInstanceOf<ITranslatedPokemonDetail>(result?.Value);
            var pokemonDetail = result?.Value as TranslatedPokemonModel;
            VerifyDetailsOfSuccessfulCall(pokemonDetail, SuccessPokemonDetail);
            Assert.That(pokemonDetail?.Information, Is.EqualTo(SuccessPokemonDetail.Information));
        }

        private void VerifyDetailsOfSuccessfulCall(IPokemonDetail pokemonDetail,
            Pokedex.Application.Models.Interfaces.IPokemonDetail details)
        {
            Assert.That(!string.IsNullOrWhiteSpace(pokemonDetail?.Description), Is.True);
            Assert.That(pokemonDetail?.Name, Is.EqualTo(details.Name));
            Assert.That(pokemonDetail?.Description, Is.EqualTo(details.Description));
            Assert.That(pokemonDetail?.Habitat, Is.EqualTo(details.Habitat));
            Assert.That(pokemonDetail?.IsLegendary, Is.EqualTo(details.IsLegendary));
            Assert.That(pokemonDetail?.Height, Is.EqualTo(details.Height));
            Assert.That(pokemonDetail?.Weight, Is.EqualTo(details.Weight));
            Assert.That(pokemonDetail?.Shape, Is.EqualTo(details.Shape));
            Assert.That(pokemonDetail?.IsBaby, Is.EqualTo(details.IsBaby));
            Assert.That(pokemonDetail?.IsMythical, Is.EqualTo(details.IsMythical));
            Assert.That(details.HasError, Is.False);
            Assert.That(details.Error, Is.EqualTo(""));
        }

        private Pokedex.Application.Models.Interfaces.IPokemonDetail SuccessPokemonDetail => GetPokemonModel(false, "");

        private PokemonController GetPokemonController() => new PokemonController(_detailRepository.Object, _mapper);

        private Pokedex.Application.Models.Interfaces.IPokemonDetail GetPokemonModel
            (bool hasError = true, string error = "an error occurred") =>
            new PokemonModel("pokemonName", "description", "habitat", true, 1, 1, "shape",
            false, false, "information", hasError, error);
    }
}