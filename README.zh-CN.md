<div align="center">
<h1 align="center"> <img alt="MrinDoc logo" src="docs/images/logo.png" width="40px" />  IGeekFan.AspNetCore.RapiDoc </h1>

**[RapiDoc](https://github.com/mrin9/RapiDoc)** Custom Element for Open-API spec viewing ，支持 .NET Core3.1 、.NET Standard2.0、.NET5.0。

一个实现了Swagger 2.0 and OpenAPI 3.0，适用于任何框架或没有框架的API文档.我将其集成到 AspNetCore 中。更多特性，请参考 **[RapiDoc](https://github.com/mrin9/RapiDoc) README**

[![nuget](https://img.shields.io/nuget/v/IGeekFan.AspNetCore.RapiDoc.svg?style=flat-square)](https://www.nuget.org/packages/IGeekFan.AspNetCore.RapiDoc)
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

## 📚 快速开始

### 🚀安装包

以下为使用Swashbuckle.AspNetCore.Swagger底层组件

1.Install the standard Nuget package into your ASP.NET Core application.

```
Package Manager : 

Install-Package IGeekFan.AspNetCore.RapiDoc

OR

CLI :

dotnet add package IGeekFan.AspNetCore.RapiDoc
```

2.In the ConfigureServices method of Startup.cs, register the Swagger generator, defining one or more Swagger documents.

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
        var filePath = Path.Combine(System.AppContext.BaseDirectory $"{typeof(Startup).Assembly.GetName().Name}.xml");
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
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapSwagger("{documentName}/api-docs");
});
```
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



### 更多配置请参考

- [https://github.com/domaindrivendev/Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [https://mrin9.github.io/RapiDoc/api.html](https://mrin9.github.io/RapiDoc/api.html)

