namespace BlazorWysiwyg.Models.Configuration;

/// <summary>
/// Configuration options for the WYSIWYG editor
/// </summary>
public class EditorOptions
{
    /// <summary>
    /// Gets or sets whether the editor should sanitize HTML content
    /// </summary>
    public bool SanitizeHtml { get; set; } = true;

    /// <summary>
    /// Gets or sets the placeholder text when the editor is empty
    /// </summary>
    public string Placeholder { get; set; } = "Enter text here...";

    /// <summary>
    /// Gets or sets whether the editor is in read-only mode
    /// </summary>
    public bool ReadOnly { get; set; } = false;

    /// <summary>
    /// Gets or sets the maximum height of the editor in pixels
    /// If null, the editor will expand indefinitely
    /// </summary>
    public int? MaxHeight { get; set; } = null;

    /// <summary>
    /// Gets or sets the minimum height of the editor in pixels
    /// </summary>
    public int MinHeight { get; set; } = 200;

    /// <summary>
    /// Gets or sets the toolbar options
    /// </summary>
    public ToolbarOptions ToolbarOptions { get; set; } = new();
}