namespace BlazorWysiwyg.Services.Icons;

using System.Collections.Generic;

using BlazorWysiwyg.Components.Icons;
using BlazorWysiwyg.Models.Configuration;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Service for providing icon components
/// </summary>
public interface IIconService
{
    /// <summary>
    /// Gets the icon component for the specified button type
    /// </summary>
    RenderFragment GetIcon(ToolbarButtonType buttonType);
}

/// <summary>
/// Default implementation of the icon service
/// </summary>
public class IconService : IIconService
{
    private readonly Dictionary<ToolbarButtonType, RenderFragment> _iconCache;

    /// <summary>
    /// Initializes a new instance of the <see cref="IconService"/> class
    /// </summary>
    public IconService()
    {
        _iconCache = [];
        RegisterIcons();
    }

    /// <summary>
    /// Gets the icon component for the specified button type
    /// </summary>
    public RenderFragment GetIcon(ToolbarButtonType buttonType)
    {
        if (_iconCache.TryGetValue(buttonType, out var icon))
        {
            return icon;
        }

        // Return empty fragment if icon not found
        return builder => { };
    }

    /// <summary>
    /// Registers all available icons
    /// </summary>
    private void RegisterIcons()
    {
        // Register icons for each button type
        _iconCache[ToolbarButtonType.Bold] = builder =>
        {
            builder.OpenComponent<BoldIcon>(0);
            builder.CloseComponent();
        };

        _iconCache[ToolbarButtonType.Italic] = builder =>
        {
            builder.OpenComponent<ItalicIcon>(0);
            builder.CloseComponent();
        };

        _iconCache[ToolbarButtonType.Underline] = builder =>
        {
            builder.OpenComponent<UnderlineIcon>(0);
            builder.CloseComponent();
        };

        // The rest of the icons would be registered here in the same way
        // For brevity, I'm only showing a few icon implementations
    }
}