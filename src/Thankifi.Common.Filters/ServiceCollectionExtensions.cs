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
            services.TryAddTransient<IFilter, BinaryFilter>();
            services.TryAddTransient<IFilter, BottomifyFilter>();
            services.TryAddTransient<IFilter, LeetFilter>();
            services.TryAddTransient<IFilter, MockFilter>();
            services.TryAddTransient<IFilter, ShoutingFilter>();

            services.TryAddTransient<IFilterService, FilterService>();
            
            return services;
        }
    }
}