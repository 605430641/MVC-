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
            _testServiceA         = testServiceA;  //瞬时
            _testServiceB         = testServiceB;       //单例
            _testServiceC         = testServiceC;            //作用域
            _testServiceD         = testServiceD;
            _testServiceE         = testServiceE;
            _serviceProvider = serviceProvider;//容器实例  实例已经全部在容器了 
        }
        public IActionResult Index()
        {
            //容器实例
            var a = this._serviceProvider.GetService<ITestServiceE>();
            Console.WriteLine($"{object.ReferenceEquals(this._testServiceA,a)}");

            ITestServiceA              ListService = _serviceProvider.GetService<ITestServiceA>(); //获取单个 会得到最后一个注册的
            IEnumerable<ITestServiceA> ListServices = _serviceProvider.GetServices<ITestServiceA>(); //获取集合
            return View();
        }
    }
}
