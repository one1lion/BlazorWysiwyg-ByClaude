namespace BlazorWysiwyg.Models.Configuration;

/// <summary>
/// Configuration options for the editor toolbar
/// </summary>
public class ToolbarOptions
{
    /// <summary>
    /// Gets or sets whether the toolbar is visible
    /// </summary>
    public bool Visible { get; set; } = true;

    /// <summary>
    /// Gets or sets whether the toolbar is fixed at the top
    /// </summary>
    public bool Fixed { get; set; } = false;

    /// <summary>
    /// Gets or sets the toolbar button groups to display
    /// </summary>
    public List<ToolbarButtonGroup> ButtonGroups { get; set; } = DefaultToolbarConfiguration();

    /// <summary>
    /// Gets the default toolbar configuration
    /// </summary>
    private static List<ToolbarButtonGroup> DefaultToolbarConfiguration() =>
    [
        new ToolbarButtonGroup
        {
            Buttons =
            [
                ToolbarButtonType.Bold,
                ToolbarButtonType.Italic,
                ToolbarButtonType.Underline,
                ToolbarButtonType.StrikeThrough
            ]
        },
        new ToolbarButtonGroup
        {
            Buttons =
            [
                ToolbarButtonType.Heading1,
                ToolbarButtonType.Heading2,
                ToolbarButtonType.Heading3,
                ToolbarButtonType.Paragraph
            ]
        },
        new ToolbarButtonGroup
        {
            Buttons =
            [
                ToolbarButtonType.BulletList,
                ToolbarButtonType.NumberedList,
                ToolbarButtonType.Indent,
                ToolbarButtonType.Outdent
            ]
        },
        new ToolbarButtonGroup
        {
            Buttons =
            [
                ToolbarButtonType.Link,
                ToolbarButtonType.Image,
                ToolbarButtonType.Table
            ]
        },
        new ToolbarButtonGroup
        {
            Buttons =
            [
                ToolbarButtonType.AlignLeft,
                ToolbarButtonType.AlignCenter,
                ToolbarButtonType.AlignRight,
                ToolbarButtonType.AlignJustify
            ]
        }
    ];
}
