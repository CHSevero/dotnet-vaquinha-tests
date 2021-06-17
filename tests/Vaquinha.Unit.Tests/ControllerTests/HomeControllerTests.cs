using Microsoft.Extensions.Logging;
using Moq;
using Vaquinha.MVC.Controllers;
using Vaquinha.Domain;
using NToastNotify;
using AutoMapper;
using Vaquinha.Service;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Vaquinha.Unit.Tests.ControllerTests
{
    public class HomeControllerTests
    {
        private HomeController _homeCrontroller;
        private readonly IHomeInfoService _homeInfoService;
        private readonly Mock<ILogger<HomeController>> _logger = new Mock<ILogger<HomeController>>();

        private Mock<IToastNotification> _toastNotification = new Mock<IToastNotification>();

        private Mock<IMapper> _mapper;
        private readonly IDoacaoService _doacaoService;
        private readonly Mock<GloballAppConfig> _globallAppConfig = new Mock<GloballAppConfig>();
        private readonly Mock<IHomeInfoRepository> _homeRepository = new Mock<IHomeInfoRepository>();
        private readonly Mock<ICausaRepository> _causaRepository = new Mock<ICausaRepository>();
        private readonly Mock<IDoacaoRepository> _doacaoRepository = new Mock<IDoacaoRepository>();
        private IDomainNotificationService _domainNotificationService = new DomainNotificationService();


        public HomeControllerTests()
        {
            _mapper = new Mock<IMapper>();
            _doacaoService = new DoacaoService(_mapper.Object, 
                                               _doacaoRepository.Object, 
                                               _domainNotificationService);

            _homeInfoService = new HomeInfoService(_mapper.Object,
                                                   _doacaoService,
                                                   _globallAppConfig.Object, 
                                                   _homeRepository.Object, 
                                                   _causaRepository.Object);
        }

        #region HTTPGET
        [Trait("HomeController", "HomeController_GETHome_ReturnoComSucesso")]
        [Fact]
        public void HomeController_GETHome_ReturnoComSucesso()
        {
            // Arrange
            _homeCrontroller = new HomeController(_logger.Object, _homeInfoService, _toastNotification.Object);

            // Act
            var retorno = _homeCrontroller.Index();

            // Assert
            retorno.Should().BeOfType<Task<IActionResult>>();
        }
        #endregion
    }
}
