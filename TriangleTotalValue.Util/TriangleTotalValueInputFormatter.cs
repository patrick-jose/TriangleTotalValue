using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace TriangleTotalValue.Util;

public class TriangleTotalValueInputFormatter : InputFormatter
{
    public TriangleTotalValueInputFormatter()
    {
        SupportedMediaTypes.Add("text/plain");
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        using (var reader = new StreamReader(request.Body))
        {
            var content = await reader.ReadToEndAsync();
            return await InputFormatterResult.SuccessAsync(content);
        }
    }

    public override bool CanRead(InputFormatterContext context)
    {
        return context.HttpContext.Request.ContentType.StartsWith("text/plain");
    }

}

