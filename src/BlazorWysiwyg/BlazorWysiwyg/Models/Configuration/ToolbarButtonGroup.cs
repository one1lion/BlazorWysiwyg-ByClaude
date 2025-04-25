namespace BlazorWysiwyg.Models.Configuration;

/// <summary>
/// Represents a group of toolbar buttons
/// </summary>
public class ToolbarButtonGroup
{
    /// <summary>
    /// Gets or sets the buttons in this group
    /// </summary>
    public List<ToolbarButtonType> Buttons { get; set; } = [];
}
