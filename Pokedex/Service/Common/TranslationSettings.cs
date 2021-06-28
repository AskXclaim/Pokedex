namespace Pokedex.Service.Common
{
    /// <summary>
    /// A class that maps to the 'TranslationSettings' section of the 'appsettings.json' file.
    /// </summary>
    public class TranslationSettings
    {
        public string TranslationApiOption1 { get; set; }
        public string TranslationApiOption2 { get; set; }
        public string Habitat { get; set; }
        public string Language { get; set; }
    }
}