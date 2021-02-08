namespace WebApi.Example
{
    using System;

    public class CicloVidaScoped : ICicloVidaScoped
    {
        private int _contador = 0;
        public CicloVidaScoped()
        {
            Nome = "Scoped";
            Identificacao = Guid.NewGuid().ToString()[^4..];
            DataHoraCriacao = DateTime.Now;
        }

        public string Nome { get; }
        public string Identificacao { get; }
        public DateTime DataHoraCriacao { get; }

        public string Retorno(string origem)
            => $"{origem,-20}|{Nome,-15}|{Identificacao,-10}|{DataHoraCriacao:HH:mm:ss.fff}   |{++_contador}";
    }

    public class CicloVidaSingleton : ICicloVidaSingleton
    {
        private int _contador = 0;
        public CicloVidaSingleton()
        {
            Nome = "Singleton";
            Identificacao = Guid.NewGuid().ToString()[^4..];
            DataHoraCriacao = DateTime.Now;
        }

        public string Nome { get; }
        public string Identificacao { get; }
        public DateTime DataHoraCriacao { get; }

        public string Retorno(string origem)
            => $"{origem,-20}|{Nome,-15}|{Identificacao,-10}|{DataHoraCriacao:HH:mm:ss.fff}   |{++_contador}";

    }

    public class CicloVidaTransient : ICicloVidaTransient
    {
        private int _contador = 0;
        public CicloVidaTransient()
        {
            Nome = "Transient";
            Identificacao = Guid.NewGuid().ToString()[^4..];
            DataHoraCriacao = DateTime.Now;
        }

        public string Nome { get; }
        public string Identificacao { get; }

        public DateTime DataHoraCriacao { get; }

        public string Retorno(string origem)
            => $"{origem,-20}|{Nome,-15}|{Identificacao,-10}|{DataHoraCriacao:HH:mm:ss.fff}   |{++_contador}";

    }
}
