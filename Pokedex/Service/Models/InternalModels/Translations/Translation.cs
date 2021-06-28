namespace Pokedex.Service.Models.InternalModels.Translations
{
    /// <summary>
    /// A class that mirrors the translation class gotten from an external API call.
    /// </summary>
    public class Translation
    {
        public Success Success { get; set; }
        public Contents Contents { get; set; }
    }
}