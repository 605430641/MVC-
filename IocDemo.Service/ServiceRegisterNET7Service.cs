using IocDemo.InterFace;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IocDemo.Service;

/// <summary>
/// 封装好 IOC注册类  减少别人使用这个框架的成本 知道那些类需要怎么注册 只需要
/// </summary>
public static class ServiceRegisterNET7Service
{
    public static void ServiceRegisterNET7ServiceVoid(this IServiceCollection serviceCollection)
    {
        
      serviceCollection.AddTransient<ITestServiceA, TestServiceA>();                         //瞬时
      serviceCollection.AddTransient<ITestServiceA, TestServiceA2>();                        //A不覆盖上面的  直接获取能获取A2 以最后的注册为准 如果想获取前面一个 可以获取集合然后得到A 如果想要覆盖如下
      serviceCollection.Replace(ServiceDescriptor.Transient<ITestServiceA,TestServiceA2>()); //A2覆盖A
      serviceCollection.AddSingleton<ITestServiceB, TestServiceB>();                         //单列模式
      serviceCollection.AddScoped<ITestServiceC, TestServiceC>();                            //作用域单列
    }
}