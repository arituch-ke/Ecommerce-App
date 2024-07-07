using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ecommerce.Server.Utils
{
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths
                .ToDictionary(entry => LowercaseEverythingButParameters(entry.Key), entry => entry.Value);

            swaggerDoc.Paths = new OpenApiPaths();
            foreach (var pathItem in paths)
            {
                swaggerDoc.Paths.Add(pathItem.Key, pathItem.Value);
            }
        }

        private static string LowercaseEverythingButParameters(string key)
        {
            return string.Join('/', key.Split('/')
                .Select(x => x.Contains("{") ? x : x.ToLower()));
        }
    }

}
