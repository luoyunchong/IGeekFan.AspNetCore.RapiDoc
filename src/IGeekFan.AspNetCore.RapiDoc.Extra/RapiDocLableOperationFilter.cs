using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace IGeekFan.AspNetCore.RapiDoc.Extra
{
    public class RapiDocLableOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<RapiDocLabelAttribute>();

            if (authAttributes.Any())
            {
                var openapiArray = new OpenApiArray();
                foreach (var item in authAttributes)
                {
                    openapiArray.Add(new OpenApiObject
                    {
                        ["color"] = new OpenApiString(item.Color.ToString().ToLower().Replace("_", "-")),
                        ["label"] = new OpenApiString(item.Label)
                    });
                }
                operation.Extensions.Add("x-badges", openapiArray);
            };
        }
    }
}
