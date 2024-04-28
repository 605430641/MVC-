
//builder.Configuration 读取配置文件帮助类 可以配置多个数据源
//builder.logging:配置下项目的日志组件 常用的log4net
//builder.setvice是ioc注册

//builder.Host

#region ioc容器替换

// builder.Host.UseServiceProviderFactory(new DefaultAuthorizationHandlerContextFactory());
#endregion

#region 创建Builder
//GOF23种设计模式之创建型模式之建造者模式 作用：将复杂对象的构造和它的表示分离,使同样的构建过程 可以创建不同的表示
//将一个复杂对象分解多个简单对象 然后一步步构建 相当于产品的组成部分不变 但是每一部分可以灵活选择
//里面创建的各种 webapplication和webHostBuilder,configBuilder 都是为了创建web程序的初始化
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.视图的builder
builder.Services.AddControllersWithViews();


#endregion


//如果加载两个配置文件 有相同的配置 取最后builder的
//builder.Configuration.AddJsonFile("appsettings.Demo.Json",true,false);

#region 日志组件扩展

builder.Logging.ClearProviders();
builder.Logging.AddConsole().AddDebug();
// builder.Logging.AddLog4Net();      、、log4组件 需要添加log4net.config 暂时没有添加
 // builder.Logging.AddFilter("System",   LogLevel.Debug); //常用的日志组件
 // builder.Logging.AddFilter("Microsoft",LogLevel.Warning); //常用的日志组件

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


#region Use中间件：管道默许配置

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


#endregion

app.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}"
                      );
 //启动坚挺——Kestrel
app.Run();