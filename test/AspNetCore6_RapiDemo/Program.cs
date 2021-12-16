using IGeekFan.AspNetCore.RapiDoc;
using IGeekFan.AspNetCore.RapiDoc.Extra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<RapiDocLableOperationFilter>();
    var filePath = Path.Combine(System.AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml");
    c.IncludeXmlComments(filePath, true);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCore6_RapiDemo", Version = "v1" });
});



builder.Services.Configure<RapiDocOptions>(c =>
{
    builder.Configuration.Bind("RapiDoc", c);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCore6_RapiDemo v1"));
    app.UseRapiDocUI(c =>
    {
        //c.RoutePrefix = ""; // serve the UI at root
        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
        //https://mrin9.github.io/RapiDoc/api.html
        //This Config Higher priority
        c.GenericRapiConfig = new GenericRapiConfig()
        {
            RenderStyle = "read",
            Theme = "light",//light | dark
            SchemaStyle = "table"////tree | table
        };

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


