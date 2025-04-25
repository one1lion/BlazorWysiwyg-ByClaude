using Microsoft.Extensions.DependencyInjection;

namespace BlazorWysiwyg.Extensions;

using BlazorWysiwyg.Models.Configuration;
using BlazorWysiwyg.Services.DOM;
using BlazorWysiwyg.Services.DOM.Interfaces;
using BlazorWysiwyg.Services.Icons;
using BlazorWysiwyg.Services.Sanitization;
using BlazorWysiwyg.Services.Sanitization.Interfaces;

/// <summary>
/// Extension methods for configuring BlazorWysiwyg services
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds BlazorWysiwyg services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configureOptions">The action used to configure the editor options.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddBlazorWysiwyg(this IServiceCollection services, Action<EditorOptions>? configureOptions = null)
    {
        // Register services
        services.AddScoped<IEditorDomHandler, EditorDomHandler>();
        services.AddScoped<ISelectionService, SelectionService>();
        services.AddScoped<IHtmlSanitizer, HtmlSanitizer>();
        services.AddSingleton<IIconService, IconService>();

        // Configure options
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }
        else
        {
            services.Configure<EditorOptions>(_ => { });
        }

        return services;
    }
}