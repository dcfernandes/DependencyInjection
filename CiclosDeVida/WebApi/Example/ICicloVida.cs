namespace WebApi.Example
{
    using System;

    public interface ICicloVida
    {
        string Nome { get; }
        string Identificacao { get; }
        DateTime DataHoraCriacao { get; }

        string Retorno(string origem);
    }

    public interface ICicloVidaScoped : ICicloVida { }
    public interface ICicloVidaTransient : ICicloVida { }
    public interface ICicloVidaSingleton : ICicloVida { }
}
