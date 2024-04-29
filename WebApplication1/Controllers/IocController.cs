using IocDemo.InterFace;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class IocController : Controller
    {
        private readonly IConfiguration   _configuration;
        private readonly ILoggerFactory   _iLoggerFactory;
        private readonly ITestServiceA    _testServiceA;
        private readonly ITestServiceB    _testServiceB;
        private readonly ITestServiceC    _testServiceC;
        private readonly ITestServiceD    _testServiceD;
        private readonly ITestServiceE    _testServiceE;
        private readonly IServiceProvider _serviceProvider;

        public IocController(
            IConfiguration configuration
            ,ILoggerFactory iLoggerFactory
            ,ILogger<IocController> loggerFactory
                      ,ITestServiceA testServiceA
                      ,ITestServiceB testServiceB
                      ,ITestServiceC testServiceC
                      ,ITestServiceD testServiceD
                      ,ITestServiceE testServiceE
            ,IServiceProvider serviceProvider
                    
            )
        {
            _configuration        = configuration;
            _iLoggerFactory       = iLoggerFactory;
            _testServiceA         = testServiceA;
            _testServiceB         = testServiceB;
            _testServiceC         = testServiceC;
            _testServiceD         = testServiceD;
            _testServiceE         = testServiceE;
            _serviceProvider = serviceProvider;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
