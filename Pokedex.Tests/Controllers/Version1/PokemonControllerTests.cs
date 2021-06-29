using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using NUnit.Framework;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Application.Models.Instances;
using Pokedex.Controllers;
using Pokedex.Controllers.Version1;
using Pokedex.Mapping;
using Pokedex.Models.Interfaces;

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

            VerifyInvalidPokemonName(actionResult, expectedResult);
        }

        private void VerifyInvalidPokemonName(ActionResult<IPokemonDetail> actionResult, string expectedResult)
        {
            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;
            var modelState = result?.Value as SerializableError;
            Assert.That(modelState?.Values.ToList().FirstOrDefault(), Is.EqualTo(expectedResult));
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
            var value = result?.Value as string;
            Assert.That(string.IsNullOrWhiteSpace(value), Is.False);
        }

        [Test]
        public async Task GetPokemon_WhenCalledSuccessfully_ReturnsOk()
        {
            _detailRepository.Setup(dr => dr.GetBasicPokemonDetails(
                It.IsAny<string>())).ReturnsAsync(GetPokemonModel(false, ""));

            var actionResult = await GetPokemonController().GetPokemon("pokemonName");

            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.IsInstanceOf<IPokemonDetail>(result?.Value);
            var pokemonDetail = result?.Value as Models.Instances.PokemonModel;
            Assert.That(!string.IsNullOrWhiteSpace(pokemonDetail?.Description), Is.True);
        }

        [TestCase("poke-name", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("poke_name", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("フシギダネ", Constants.PokemonNameShouldBeAlphabetsOnly)]
        [TestCase("", Constants.PokemonNameRequired)]
        [TestCase(null, Constants.PokemonNameRequired)]
        public async Task GetTranslatedPokemon_WhenCalledWithAnInvalidPokemonName_ReturnsBadRequest(string pokemonName, string expectedResult)
        {
            var actionResult = await GetPokemonController().GetTranslatedPokemon(pokemonName);

            VerifyInvalidPokemonName(actionResult, expectedResult);
        }

        private void VerifyInvalidPokemonName(ActionResult<ITranslatedPokemonDetail> actionResult, string expectedResult)
        {
            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
            var result = actionResult.Result as BadRequestObjectResult;
            var modelState = result?.Value as SerializableError;
            Assert.That(modelState?.Values.ToList().FirstOrDefault(), Is.EqualTo(expectedResult));
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
            var value = result?.Value as string;
            Assert.That(string.IsNullOrWhiteSpace(value), Is.False);
        }

        [Test]
        public async Task GetTranslatedPokemon_WhenCalledSuccessfully_ReturnsOk()
        {
            _detailRepository.Setup(dr => dr.GetTranslatedPokemonDetails(
                It.IsAny<string>())).ReturnsAsync(GetPokemonModel(false, ""));

            var actionResult = await GetPokemonController().GetTranslatedPokemon("pokemonName");

            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.IsInstanceOf<ITranslatedPokemonDetail>(result?.Value);
            var pokemonDetail = result?.Value as Models.Instances.TranslatedPokemonModel;
            Assert.That(!string.IsNullOrWhiteSpace(pokemonDetail?.Description), Is.True);
        }

        private PokemonController GetPokemonController() => new PokemonController(_detailRepository.Object, _mapper);

        private Pokedex.Application.Models.Interfaces.IPokemonDetail GetPokemonModel
            (bool hasError = true, string error = "an error occurred") =>
            new PokemonModel("pokemonName", "description", "habitat", true, 1, 1, "shape",
            false, false, "information", hasError, error);
    }
}