using FluentAssertions;
using System.Threading.Tasks;
using Vaquinha.Domain.Extensions;
using Vaquinha.Integration.Tests.Fixtures;
using Vaquinha.MVC;
using Xunit;

namespace Vaquinha.Integration.Tests
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class DoacaoTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _integrationTestsFixture;

        public DoacaoTests(IntegrationTestsFixture<StartupWebTests> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Trait("DoacaoControllerIntegrationTests", "DoacaoController_CarregarPaginaDoacao")]
        [Fact]
        public async Task DoacaoController_CarregarPaginaDoacao()
        {
            // Arrange & Act
            var doacao = await _integrationTestsFixture.Client.GetAsync("Doacoes/Create");

            // Assert
            doacao.EnsureSuccessStatusCode();
        }
    }
}