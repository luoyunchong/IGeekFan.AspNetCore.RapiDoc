<div align="center">
<h1 align="center"> <img alt="MrinDoc logo" src="docs/images/logo.png" width="40px" />  IGeekFan.AspNetCore.RapiDoc </h1>

**[RapiDoc](https://github.com/mrin9/RapiDoc)** Custom Element for Open-API spec viewing ，支持 .NET Core3.1 、.NET Standard2.0、.NET5.0、.NET6.0。

一个实现了Swagger 2.0 and OpenAPI 3.0，适用于任何框架或没有框架的API文档.我将其集成到 AspNetCore 中。更多特性，请参考 **[RapiDoc](https://github.com/mrin9/RapiDoc) README**

[![RapiDoc](https://img.shields.io/nuget/v/IGeekFan.AspNetCore.RapiDoc.svg?style=flat-square&color=fedcba)](https://www.nuget.org/packages/IGeekFan.AspNetCore.RapiDoc)
[![RapiDoc.Extra](https://img.shields.io/nuget/v/IGeekFan.AspNetCore.RapiDoc.Extra.svg?style=flat-square)](https://www.nuget.org/packages/IGeekFan.AspNetCore.RapiDoc.Extra)
[![stats](https://img.shields.io/nuget/dt/IGeekFan.AspNetCore.RapiDoc.svg?style=flat-square)](https://www.nuget.org/stats/packages/IGeekFan.AspNetCore.RapiDoc?groupby=Version) [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/luoyunchong/IGeekFan.AspNetCore.RapiDoc/master/LICENSE)

<p>
    <a href="README.md">English</a> |  
    <span>中文</span> |  
</p>
</div>

## 相关依赖项
### [RapiDoc](https://github.com/mrin9/RapiDoc)
- rapidoc^(version) [https://www.npmjs.com/package/rapidoc](https://www.npmjs.com/package/rapidoc)
### [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Swashbuckle.AspNetCore.Swagger
- Swashbuckle.AspNetCore.SwaggerGen

## Demo
- [Basic](https://github.com/luoyunchong/IGeekFan.AspNetCore.RapiDoc/blob/master/test/Basic)
- [RapiDocDemo](https://github.com/luoyunchong/IGeekFan.AspNetCore.RapiDoc/blob/master/test/RapiDocDemo)
- [OAuth2Integration](https://github.com/luoyunchong/IGeekFan.AspNetCore.RapiDoc/blob/master/test/WebSites/OAuth2Integration)
- [ASPNET Core 6](https://github.com/luoyunchong/IGeekFan.AspNetCore.RapiDoc/blob/master/test/AspNetCore6_RapiDemo)
## 📚 快速开始

### 🚀安装包

你需要安装`Swashbuckle.AspNetCore.Swagger`相关包。

1.通过Nuget或CLI将包安装到ASP.NET Core应用中,如下：

```
Package Manager : 

Install-Package Swashbuckle.AspNetCore.Swagger
Install-Package Swashbuckle.AspNetCore.SwaggerGen
Install-Package IGeekFan.AspNetCore.RapiDoc

CLI :

dotnet add package Swashbuckle.AspNetCore.Swagger
dotnet add package Swashbuckle.AspNetCore.SwaggerGen
dotnet add package IGeekFan.AspNetCore.RapiDoc
```

2.在  Startup.cs 中 的ConfigureServices 方法, 注入 Swagger generator服务，用于配置我们的swagger文档

```
using Microsoft.AspNetCore.Mvc.Controllers
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using IGeekFan.AspNetCore.RapiDoc;
```
### 🚁 ConfigureServices

3.服务配置
```
   services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",new OpenApiInfo{Title = "API V1",Version = "v1"});
        var filePath = Path.Combine(System.AppContext.BaseDirectory,$"{typeof(Startup).Assembly.GetName().Name}.xml");
        c.IncludeXmlComments(filePath, true);
    });
```

### 💪 Configure
4. 中间件配置
```
app.UseSwagger();

app.UseRapiDocUI(c =>
{
    c.RoutePrefix = ""; // serve the UI at root
    c.SwaggerEndpoint("/v1/api-docs", "V1 Docs");
    c.GenericRapiConfig = new GenericRapiConfig()
    {
        RenderStyle="focused",
        Theme="light", //light,dark,focused   
    };
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapSwagger("{documentName}/api-docs");
});
```
[https://mrin9.github.io/RapiDoc/api.html](https://mrin9.github.io/RapiDoc/api.html) GenericRapiConfig 配置项参考此文档
即可使用 RapiDoc

### 🔎 效果图
运行项目，打开 https://localhost:5001/index.html#/home
![docs/images/view.png](docs/images/view.png)

5.更多功能

为文档添加注释 在项目上右键--属性--生成

![](https://pic.downk.cc/item/5f34161d14195aa59413f0fc.jpg)

在AddSwaggerGen方法中添加如下代码

```
c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SwaggerDemo.xml"),true);
```
 最后一个参数设置为true，代表启用控制器上的注释


### NSwag.AspNetCore
（请参考目录test/WebSites/NSwag.Swagger.RapiDoc）

另一种方式。
```
Package Manager : 

Install-Package IGeekFan.AspNetCore.RapiDoc

OR

CLI :

dotnet add package NSwag.AspNetCore
```

```
public void ConfigureServices(IServiceCollection services)
 {
    // 其它Service
     services.AddOpenApiDocument();
 }
```

```
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
        // 其它 Use
      app.UseOpenApi();
      app.UseRapiDocUI(c =>
     {
           c.RoutePrefix = "";
           c.SwaggerEndpoint("/swagger/v1/swagger.json");
      });
}
```

### IGeekFan.AspNetCore.RapiDoc.Extra
只有一个类，通过`Filter`实现方法上显示标签

安装包
```
dotnet add package IGeekFan.AspNetCore.RapiDoc.Extra
```

在AddSwaggerGen服务中增加`RapiDocLableOperationFilter`过滤器、

当然，你需要引用命名空间`IGeekFan.AspNetCore.RapiDoc.Extra`

```diff
builder.Services.AddSwaggerGen(c =>
{
+   c.OperationFilter<RapiDocLableOperationFilter>();
    var filePath = Path.Combine(System.AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml");
    c.IncludeXmlComments(filePath, true);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCore6_RapiDemo", Version = "v1" });
});
```


在Controller
```diff
+   [RapiDocLabel("Core Api")]
+   [RapiDocLabel("Test",RapiDocColor.RED)]
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return null;
    }
```
效果图如下

![docs/images/light-badges.png](docs/images/light-badges.png)

- 通过appsettings.json配置

```csharp
builder.Services.Configure<RapiDocOptions>(c =>{
    builder.Configuration.Bind("RapiDoc", c);
});
```

aoosettings.json
```json
 "RapiDoc": {
    "RoutePrefix": "swagger",
    "DocumentTitle": "ASPNET CORE 6 RAPI DOC",
    "GenericRapiConfig": {
      "Theme": "dark"
    }
  }
```
其中 通过中间件的配置优先级更高。所有配置项都可以在项目中的appsettings.json中配置，请参考 [https://mrin9.github.io/RapiDoc/api.html](https://mrin9.github.io/RapiDoc/api.html)
```csharp
 app.UseRapiDocUI(c =>
    {
        //This Config Higher priority
        c.GenericRapiConfig = new GenericRapiConfig()
        {
            RenderStyle= "read",//read | view | focused
            Theme="light",//light | dark
            SchemaStyle= "table"//tree | table
        };

    });
```



### 更多配置请参考

- [https://github.com/domaindrivendev/Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [https://mrin9.github.io/RapiDoc/api.html](https://mrin9.github.io/RapiDoc/api.html)

