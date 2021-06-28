namespace Pokedex.Service.Models.InternalModels.Translations
{
    /// <summary>
    /// A class that mirrors the Contents class gotten from an external API call.
    /// </summary>
    public class Contents
    {
        public string Translated { get; set; }
        public string Text { get; set; }
        public string Translation { get; set; }
    }
}