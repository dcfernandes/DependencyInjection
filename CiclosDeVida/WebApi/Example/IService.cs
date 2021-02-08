namespace WebApi.Example
{
    public interface IService
    {
        string RetornoTransient();
        string RetornoScoped();
        string RetornoSingleton();
    }
}
