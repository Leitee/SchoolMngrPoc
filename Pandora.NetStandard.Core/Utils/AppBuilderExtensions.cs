using Microsoft.AspNetCore.Builder;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIf(this IApplicationBuilder app, bool condition, Func<IApplicationBuilder, IApplicationBuilder> action)
        {
            return condition ? action(app) : app;
        }
    }
}
