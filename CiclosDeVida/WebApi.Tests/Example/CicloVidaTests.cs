using WebApi.Example;
using Xunit;

namespace WebApi.Tests.Example;

public class CicloVidaTests
{
    [Fact]
    public void CicloVidaScoped_Nome_DeveRetornarScoped()
    {
        var ciclo = new CicloVidaScoped();
        Assert.Equal("Scoped", ciclo.Nome);
    }

    [Fact]
    public void CicloVidaScoped_Identificacao_NaoDeveSerNulaOuVazia()
    {
        var ciclo = new CicloVidaScoped();
        Assert.False(string.IsNullOrEmpty(ciclo.Identificacao));
    }

    [Fact]
    public void CicloVidaScoped_Identificacao_DeveTer4Caracteres()
    {
        var ciclo = new CicloVidaScoped();
        Assert.Equal(4, ciclo.Identificacao.Length);
    }

    [Fact]
    public void CicloVidaScoped_DataHoraCriacao_NaoDeveSerDefault()
    {
        var ciclo = new CicloVidaScoped();
        Assert.NotEqual(default, ciclo.DataHoraCriacao);
    }

    [Fact]
    public void CicloVidaScoped_Retorno_DeveConterNomeEIdentificacao()
    {
        var ciclo = new CicloVidaScoped();
        var result = ciclo.Retorno("Teste");
        Assert.Contains("Scoped", result);
        Assert.Contains(ciclo.Identificacao, result);
    }

    [Fact]
    public void CicloVidaScoped_Retorno_ContadorDeveIncrementar()
    {
        var ciclo = new CicloVidaScoped();
        var first = ciclo.Retorno("A");
        var second = ciclo.Retorno("A");
        Assert.EndsWith("1", first.TrimEnd());
        Assert.EndsWith("2", second.TrimEnd());
    }

    [Fact]
    public void CicloVidaSingleton_Nome_DeveRetornarSingleton()
    {
        var ciclo = new CicloVidaSingleton();
        Assert.Equal("Singleton", ciclo.Nome);
    }

    [Fact]
    public void CicloVidaSingleton_Identificacao_DeveTer4Caracteres()
    {
        var ciclo = new CicloVidaSingleton();
        Assert.Equal(4, ciclo.Identificacao.Length);
    }

    [Fact]
    public void CicloVidaSingleton_Retorno_ContadorDeveIncrementar()
    {
        var ciclo = new CicloVidaSingleton();
        var first = ciclo.Retorno("A");
        var second = ciclo.Retorno("A");
        Assert.EndsWith("1", first.TrimEnd());
        Assert.EndsWith("2", second.TrimEnd());
    }

    [Fact]
    public void CicloVidaTransient_Nome_DeveRetornarTransient()
    {
        var ciclo = new CicloVidaTransient();
        Assert.Equal("Transient", ciclo.Nome);
    }

    [Fact]
    public void CicloVidaTransient_Identificacao_DeveTer4Caracteres()
    {
        var ciclo = new CicloVidaTransient();
        Assert.Equal(4, ciclo.Identificacao.Length);
    }

    [Fact]
    public void CicloVidaTransient_Retorno_ContadorDeveIncrementar()
    {
        var ciclo = new CicloVidaTransient();
        var first = ciclo.Retorno("A");
        var second = ciclo.Retorno("A");
        Assert.EndsWith("1", first.TrimEnd());
        Assert.EndsWith("2", second.TrimEnd());
    }

    [Fact]
    public void DoisCicloVidaTransient_DevemTerIdentificacoesDistintas()
    {
        var ciclo1 = new CicloVidaTransient();
        var ciclo2 = new CicloVidaTransient();
        Assert.NotEqual(ciclo1.Identificacao, ciclo2.Identificacao);
    }
}
