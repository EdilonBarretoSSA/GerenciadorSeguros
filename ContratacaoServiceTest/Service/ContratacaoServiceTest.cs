using NUnit.Framework;
using Moq;
using Domain.Ports.Service;
using ContratacaoAPI.Controllers;

namespace ContratacaoServiceTest.Service
{
    [TestFixture]
    public class ContratacaoControllerTests
    {
        private Mock<ISeguroService> _seguroServiceMock;
#pragma warning disable NUnit1032
        private ContratacaoController _controller;
#pragma warning restore NUnit1032

        [SetUp]
        public void Setup()
        {
            _seguroServiceMock = new Mock<ISeguroService>();
            _controller = new ContratacaoController(_seguroServiceMock.Object);
        }

        [Test]
        public void Post_Deve_Chamar_Contratar_No_SeguroService()
        {
            var numeroProposta = "PROP-123";

            _controller.Post(numeroProposta);
            _seguroServiceMock.Verify(
                s => s.Contratar(numeroProposta),
                Times.Once
            );
        }

        [Test]
        public void Get_Deve_Chamar_ObterStatus_No_SeguroService()
        {
            var numeroProposta = "PROP-456";

            _controller.Get(numeroProposta);
            _seguroServiceMock.Verify(
                s => s.ObterStatus(numeroProposta),
                Times.Once
            );
        }
    }
}