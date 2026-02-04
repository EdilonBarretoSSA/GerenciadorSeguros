using Domain.Entitys;
using Domain.Enums;
using Domain.Ports.Service;
using Moq;
using NUnit.Framework;
using PropostaAPI.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

[TestFixture]
public class PropostaControllerTests
{
    private Mock<IPropostaService> _propostaServiceMock;
#pragma warning disable NUnit1032 
    private PropostaController _controller;
#pragma warning restore NUnit1032 

    [SetUp]
    public void Setup()
    {
        _propostaServiceMock = new Mock<IPropostaService>();
        _controller = new PropostaController(_propostaServiceMock.Object);
    }

    [Test]
    public async Task Post_Deve_Chamar_SalvarAsync()
    {
        var proposta = new PropostaSeguro
        {
            NumeroProposta = "123",
            Status = EStatusProposta.Aprovada
        };

        await _controller.Post(proposta);

        _propostaServiceMock.Verify(
            s => s.SalvarAsync(proposta),
            Times.Once
        );
    }

    [Test]
    public async Task Get_Deve_Retornar_Lista_De_Propostas()
    {
        var propostasMock = new List<PropostaSeguro>
        {
            new PropostaSeguro { NumeroProposta = "123" },
            new PropostaSeguro { NumeroProposta = "456" }
        };

        _propostaServiceMock
            .Setup(s => s.ObterAsync(It.IsAny<PropostaSeguro>()))
            .ReturnsAsync(propostasMock);

        var resultado = await _controller.Get(
            numeroProposta: "123",
            cpf: "12345678900",
            nome: "João",
            rg: "123456"
        );

        Assert.That(resultado, Is.Not.Null);
        Assert.That(resultado, Has.Exactly(2).Items);

        _propostaServiceMock.Verify(
            s => s.ObterAsync(It.Is<PropostaSeguro>(p =>
                p.NumeroProposta == "123" &&
                p.Cliente.CPF == "12345678900" &&
                p.Cliente.Nome == "João" &&
                p.Cliente.RG == "123456"
            )),
            Times.Once
        );
    }

    [Test]
    public async Task Put_Deve_Chamar_AtualizarAsync_Com_Status_Correto()
    {

        var numeroProposta = "123";
        var status = "Aprovada";

        await _controller.Put(numeroProposta, status);

        _propostaServiceMock.Verify(
            s => s.AtualizarAsync(It.Is<PropostaSeguro>(p =>
                p.NumeroProposta == numeroProposta &&
                p.Status == EStatusProposta.Aprovada
            )),
            Times.Once
        );
    }
}
