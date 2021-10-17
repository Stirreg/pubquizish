using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace Pubquizish
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            string? input = value?.ToString();

            if (input == null) { return null; }

            return Regex.Replace(input,
                                 "([a-z])([A-Z])",
                                 "$1-$2",
                                 RegexOptions.CultureInvariant,
                                 TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
        }
    }
}
