﻿using System;
using System.Threading.Tasks;
using Pokedex.Application.Infrastructure.Interfaces;
using Pokedex.Application.Models.Instances;
using Pokedex.Application.Models.Interfaces;
using Pokedex.Service.Infrastructure.Interfaces;
using Pokedex.Service.Models.ReturnedModels.Interfaces;
using IBasicPokemonDetail = Pokedex.Application.Models.Interfaces.IBasicPokemonDetail;
using IMorePokemonDetail = Pokedex.Application.Models.Interfaces.IMorePokemonDetail;

namespace Pokedex.Application.Infrastructure.Instances
{
    /// <summary>
    /// A Repository class to use to get pokemon details.
    /// </summary>
    /// <inheritdoc/>
    public class PokemonDetailRepository : IPokemonDetailRepository
    {
        private readonly IPokemonDetailService _detailService;
        private const string Empty = "";

        public PokemonDetailRepository(IPokemonDetailService detailService)
        {
            _detailService = detailService ?? throw new ArgumentNullException(nameof(detailService));
        }

        public async Task<IBasicPokemonDetail> GetBasicPokemonDetails(string pokemonName)
        {
            try
            {
                var response = await _detailService.GetBasicPokemonDetails(pokemonName);

                return GetBasicPokemonModel(response);
            }
            catch (Exception ex)
            {
                return GetBasicPokemonModel(FormatError(ex, pokemonName));
            }
        }

        private IBasicPokemonDetail GetBasicPokemonModel(Service.Models.ReturnedModels.Interfaces.IBasicPokemonDetail response) =>
        new BasicPokemonModel(response.Name, response.Description, response.Habitat, response.IsLegendary, false);

        private IBasicPokemonDetail GetBasicPokemonModel(string error) =>
        new BasicPokemonModel(Empty, Empty, Empty, null, true, error);

        public async Task<IMorePokemonDetail> GetTranslatedPokemonDetails(string pokemonName)
        {
            try
            {
                var response = await _detailService.GetTranslatedPokemonDetails(pokemonName);

                return GetDetailedPokemonModel(response);
            }
            catch (Exception ex)
            {
                return GetDetailedPokemonModel(FormatError(ex, pokemonName));
            }
        }

        private IMorePokemonDetail GetDetailedPokemonModel(string error) =>
        new DetailedPokemonModel(Empty, Empty, Empty, null, null, null, Empty, null, null, Empty, true, error);

        private IMorePokemonDetail GetDetailedPokemonModel(Service.Models.ReturnedModels.Interfaces.IMorePokemonDetail response) =>
        new DetailedPokemonModel(response.Name, response.Description, response.Habitat, response.IsLegendary,
        response.Height, response.Weight, response.Shape, response.IsBaby, response.IsMythical,
        response.Information, false, Empty);

        private string FormatError(Exception ex, string pokemonName) =>
           (string.Format(Constants.ExceptionText, pokemonName, ex.Message, Environment.NewLine));
    }
}