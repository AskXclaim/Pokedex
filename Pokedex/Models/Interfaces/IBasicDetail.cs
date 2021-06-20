namespace Pokedex.Models.Interfaces
{
    public interface IBasicDetail
    {
        string Name { get; }
        string Description { get; }
        string Habitat { get; }
        bool IsLegendary { get; }
    }
}