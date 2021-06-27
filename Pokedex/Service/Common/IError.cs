namespace Pokedex.Service.Common
{
    public interface IError
    {
        bool HasError { get; }
        string Error { get; }
    }
}