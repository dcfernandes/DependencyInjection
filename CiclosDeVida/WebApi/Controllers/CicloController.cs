// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Text;
    using WebApi.Example;

    [Route("ciclo-vida")]
    [ApiController]
    public class CicloController : ControllerBase
    {
        private readonly Service _service;

        private readonly ICicloVidaSingleton _singleton;
        private readonly ICicloVidaScoped _scoped;
        private readonly ICicloVidaTransient _transient;

        public CicloController(Service service, ICicloVidaSingleton singleton, ICicloVidaScoped scoped, ICicloVidaTransient transient)
        {
            _service = service;
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new StringBuilder();

            result.AppendLine($"Origem              |Ciclo de Vida  |Id        |DataHora       |Requests");
            result.AppendLine(_transient.Retorno("Controller     "));
            result.AppendLine(_service.RetornoTransient());

            result.AppendLine(_scoped.Retorno("Controller     "));
            result.AppendLine(_service.RetornoScoped());

            result.AppendLine(_singleton.Retorno("Controller     "));
            result.AppendLine(_service.RetornoSingleton());

            return Ok(result.ToString());
        }
    }
}
