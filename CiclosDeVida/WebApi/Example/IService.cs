namespace WebApi.Example
{
    using System;
    using System.Text;
    using System.Threading;

    public interface IService
    {
        string RetornoTransient();
        string RetornoScoped();
        string RetornoSingleton();
    }

    public class Service : IService
    {
        private readonly ICicloVidaSingleton _singleton;
        private readonly ICicloVidaScoped _scoped;
        private readonly ICicloVidaTransient _transient;

        public Service(ICicloVidaSingleton singleton, ICicloVidaScoped scoped, ICicloVidaTransient transient)
        {
            _singleton = singleton ?? throw new ArgumentNullException(nameof(singleton));
            _scoped = scoped ?? throw new ArgumentNullException(nameof(scoped));
            _transient = transient ?? throw new ArgumentNullException(nameof(transient));
        }

        public string RetornoTransient()
        {
            var result = new StringBuilder();

            Thread.Sleep(1500);
            result.AppendLine(_transient.Retorno("Service Call 1 " ));

            Thread.Sleep(1500);
            result.AppendLine(_transient.Retorno("Service Call 2 "));

            return result.ToString();
        }

        public string RetornoScoped()
        {
            var result = new StringBuilder();

            Thread.Sleep(1500);
            result.AppendLine(_scoped.Retorno("Service Call 1 " ));

            Thread.Sleep(1500);
            result.AppendLine(_scoped.Retorno("Service Call 2 "));

            return result.ToString();
        }

        public string RetornoSingleton()
        {
            var result = new StringBuilder();

            Thread.Sleep(1500);
            result.AppendLine(_singleton.Retorno("Service Call 1 " ));

            Thread.Sleep(1500);
            result.AppendLine(_singleton.Retorno("Service Call 2 "));

            return result.ToString();
        }
    }
}
