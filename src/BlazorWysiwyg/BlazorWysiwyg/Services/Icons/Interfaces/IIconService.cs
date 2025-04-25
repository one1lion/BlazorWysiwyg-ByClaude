namespace BlazorWysiwyg.Services.Icons.Interfaces;

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
