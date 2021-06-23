namespace Pokedex.Models.Interfaces
{
    public interface IMoreDetail : IBasicDetail
    {
        int Height { get; }
        int Weight { get; }
    }
}