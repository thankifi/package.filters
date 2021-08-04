using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds filters and related services to the container.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.TryAddTransient<IFilterService, FilterService>();

            services.AddTransient<IFilter, BinaryFilter>();
            services.AddTransient<IFilter, BottomifyFilter>();
            services.AddTransient<IFilter, LeetFilter>();
            services.AddTransient<IFilter, MockFilter>();
            services.AddTransient<IFilter, ShoutingFilter>();
            
            return services;
        }
    }
}