using Moq;
using WebApi.Example;
using Xunit;

namespace WebApi.Tests.Example;

public class ServiceTests
{
    private readonly Mock<ICicloVidaSingleton> _singletonMock = new();
    private readonly Mock<ICicloVidaScoped> _scopedMock = new();
    private readonly Mock<ICicloVidaTransient> _transientMock = new();

    [Fact]
    public void Constructor_ComSingletonNulo_DeveLancarArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Service(null!, _scopedMock.Object, _transientMock.Object));
    }

    [Fact]
    public void Constructor_ComScopedNulo_DeveLancarArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Service(_singletonMock.Object, null!, _transientMock.Object));
    }

    [Fact]
    public void Constructor_ComTransientNulo_DeveLancarArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Service(_singletonMock.Object, _scopedMock.Object, null!));
    }

    [Fact]
    public void RetornoTransient_DeveConterResultadoDoTransient()
    {
        _transientMock.Setup(t => t.Retorno(It.IsAny<string>())).Returns("linha transient");
        var service = new Service(_singletonMock.Object, _scopedMock.Object, _transientMock.Object);

        var result = service.RetornoTransient();

        Assert.Contains("linha transient", result);
    }

    [Fact]
    public void RetornoScoped_DeveConterResultadoDoScoped()
    {
        _scopedMock.Setup(s => s.Retorno(It.IsAny<string>())).Returns("linha scoped");
        var service = new Service(_singletonMock.Object, _scopedMock.Object, _transientMock.Object);

        var result = service.RetornoScoped();

        Assert.Contains("linha scoped", result);
    }

    [Fact]
    public void RetornoSingleton_DeveConterResultadoDoSingleton()
    {
        _singletonMock.Setup(s => s.Retorno(It.IsAny<string>())).Returns("linha singleton");
        var service = new Service(_singletonMock.Object, _scopedMock.Object, _transientMock.Object);

        var result = service.RetornoSingleton();

        Assert.Contains("linha singleton", result);
    }

    [Fact]
    public void RetornoTransient_DeveInvocarRetornoDoTransientDuasVezes()
    {
        _transientMock.Setup(t => t.Retorno(It.IsAny<string>())).Returns("ok");
        var service = new Service(_singletonMock.Object, _scopedMock.Object, _transientMock.Object);

        service.RetornoTransient();

        _transientMock.Verify(t => t.Retorno(It.IsAny<string>()), Times.Exactly(2));
    }
}
