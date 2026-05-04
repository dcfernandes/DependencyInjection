using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Example;
using Xunit;

namespace WebApi.Tests.Controllers;

public class CicloControllerTests
{
    private readonly Mock<IService> _serviceMock = new();
    private readonly Mock<ICicloVidaSingleton> _singletonMock = new();
    private readonly Mock<ICicloVidaScoped> _scopedMock = new();
    private readonly Mock<ICicloVidaTransient> _transientMock = new();

    private CicloController CreateController() =>
        new(_serviceMock.Object, _singletonMock.Object, _scopedMock.Object, _transientMock.Object);

    private void SetupMocks()
    {
        _transientMock.Setup(t => t.Retorno(It.IsAny<string>())).Returns("transient-linha");
        _scopedMock.Setup(s => s.Retorno(It.IsAny<string>())).Returns("scoped-linha");
        _singletonMock.Setup(s => s.Retorno(It.IsAny<string>())).Returns("singleton-linha");
        _serviceMock.Setup(s => s.RetornoTransient()).Returns("service-transient");
        _serviceMock.Setup(s => s.RetornoScoped()).Returns("service-scoped");
        _serviceMock.Setup(s => s.RetornoSingleton()).Returns("service-singleton");
    }

    [Fact]
    public void Get_DeveRetornarOkResult()
    {
        SetupMocks();
        var result = CreateController().Get();
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Get_DeveConterCabecalho()
    {
        SetupMocks();
        var result = (OkObjectResult)CreateController().Get();
        Assert.Contains("Ciclo de Vida", result.Value!.ToString());
    }

    [Fact]
    public void Get_DeveConterResultadoDoTransientDoController()
    {
        SetupMocks();
        var result = (OkObjectResult)CreateController().Get();
        Assert.Contains("transient-linha", result.Value!.ToString());
    }

    [Fact]
    public void Get_DeveConterResultadoDoServiceTransient()
    {
        SetupMocks();
        var result = (OkObjectResult)CreateController().Get();
        Assert.Contains("service-transient", result.Value!.ToString());
    }

    [Fact]
    public void Get_DeveInvocarTodosOsMetodosDoService()
    {
        SetupMocks();
        CreateController().Get();

        _serviceMock.Verify(s => s.RetornoTransient(), Times.Once);
        _serviceMock.Verify(s => s.RetornoScoped(), Times.Once);
        _serviceMock.Verify(s => s.RetornoSingleton(), Times.Once);
    }

    [Fact]
    public void Get_DeveInvocarRetornoDeTodasAsDependencias()
    {
        SetupMocks();
        CreateController().Get();

        _transientMock.Verify(t => t.Retorno(It.IsAny<string>()), Times.Once);
        _scopedMock.Verify(s => s.Retorno(It.IsAny<string>()), Times.Once);
        _singletonMock.Verify(s => s.Retorno(It.IsAny<string>()), Times.Once);
    }
}
