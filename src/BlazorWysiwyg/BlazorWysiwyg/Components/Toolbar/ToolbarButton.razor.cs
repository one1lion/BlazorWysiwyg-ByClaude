namespace BlazorWysiwyg.Components.Toolbar;

using BlazorWysiwyg.Models.Configuration;
using BlazorWysiwyg.Services.Icons.Interfaces;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Toolbar button component
/// </summary>
public partial class ToolbarButton : ComponentBase
{
    [Inject] private IIconService IconService { get; set; } = default!;

    /// <summary>
    /// Gets or sets the button type
    /// </summary>
    [Parameter]
    public ToolbarButtonType ButtonType { get; set; }

    /// <summary>
    /// Gets or sets whether the button is active
    /// </summary>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets whether the button is disabled
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Event callback for when the button is clicked
    /// </summary>
    [Parameter]
    public EventCallback OnClick { get; set; }

    /// <summary>
    /// Gets the button title
    /// </summary>
    protected string GetButtonTitle()
    {
        return ButtonType switch
        {
            ToolbarButtonType.Bold => "Bold",
            ToolbarButtonType.Italic => "Italic",
            ToolbarButtonType.Underline => "Underline",
            ToolbarButtonType.StrikeThrough => "Strikethrough",
            ToolbarButtonType.Heading1 => "Heading 1",
            ToolbarButtonType.Heading2 => "Heading 2",
            ToolbarButtonType.Heading3 => "Heading 3",
            ToolbarButtonType.Paragraph => "Paragraph",
            ToolbarButtonType.BulletList => "Bullet List",
            ToolbarButtonType.NumberedList => "Numbered List",
            ToolbarButtonType.Indent => "Indent",
            ToolbarButtonType.Outdent => "Outdent",
            ToolbarButtonType.Link => "Link",
            ToolbarButtonType.Image => "Image",
            ToolbarButtonType.Table => "Table",
            ToolbarButtonType.AlignLeft => "Align Left",
            ToolbarButtonType.AlignCenter => "Align Center",
            ToolbarButtonType.AlignRight => "Align Right",
            ToolbarButtonType.AlignJustify => "Justify",
            ToolbarButtonType.Code => "Code",
            ToolbarButtonType.CodeBlock => "Code Block",
            ToolbarButtonType.Quote => "Quote",
            ToolbarButtonType.ClearFormatting => "Clear Formatting",
            ToolbarButtonType.Undo => "Undo",
            ToolbarButtonType.Redo => "Redo",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Gets the button class
    /// </summary>
    protected string GetButtonClass()
    {
        return $"btn-{ButtonType.ToString().ToLowerInvariant()}";
    }

    /// <summary>
    /// Gets the icon for this button
    /// </summary>
    protected RenderFragment GetButtonIcon() => IconService.GetIcon(ButtonType);
}
