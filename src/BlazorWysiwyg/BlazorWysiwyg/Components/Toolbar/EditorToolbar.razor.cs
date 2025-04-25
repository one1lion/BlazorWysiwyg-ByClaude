namespace BlazorWysiwyg.Components.Toolbar;

using BlazorWysiwyg.Models.Commands;
using BlazorWysiwyg.Models.Configuration;
using BlazorWysiwyg.Models.State;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Toolbar component for the WYSIWYG editor
/// </summary>
public partial class EditorToolbar : ComponentBase
{
    /// <summary>
    /// Gets or sets the toolbar button groups
    /// </summary>
    [Parameter]
    public List<ToolbarButtonGroup> ButtonGroups { get; set; } = new();

    /// <summary>
    /// Gets or sets whether the toolbar is fixed
    /// </summary>
    [Parameter]
    public bool Fixed { get; set; } = false;

    /// <summary>
    /// Gets or sets the editor state
    /// </summary>
    [Parameter]
    public EditorState EditorState { get; set; } = new();

    /// <summary>
    /// Event callback for when a command is executed
    /// </summary>
    [Parameter]
    public EventCallback<EditorCommand> OnCommandExecuted { get; set; }

    /// <summary>
    /// Handles a button click
    /// </summary>
    protected async Task HandleButtonClick(ToolbarButtonType buttonType)
    {
        var command = CreateCommand(buttonType);

        if (command != null)
        {
            await OnCommandExecuted.InvokeAsync(command);
        }
    }

    /// <summary>
    /// Checks if a button is active
    /// </summary>
    protected bool IsButtonActive(ToolbarButtonType buttonType)
    {
        return buttonType switch
        {
            ToolbarButtonType.Bold => EditorState.ActiveFormats.Contains("bold"),
            ToolbarButtonType.Italic => EditorState.ActiveFormats.Contains("italic"),
            ToolbarButtonType.Underline => EditorState.ActiveFormats.Contains("underline"),
            ToolbarButtonType.StrikeThrough => EditorState.ActiveFormats.Contains("strikethrough"),
            ToolbarButtonType.AlignLeft => EditorState.ActiveFormats.Contains("align-left"),
            ToolbarButtonType.AlignCenter => EditorState.ActiveFormats.Contains("align-center"),
            ToolbarButtonType.AlignRight => EditorState.ActiveFormats.Contains("align-right"),
            ToolbarButtonType.AlignJustify => EditorState.ActiveFormats.Contains("align-justify"),
            ToolbarButtonType.BulletList => EditorState.ActiveFormats.Contains("ul"),
            ToolbarButtonType.NumberedList => EditorState.ActiveFormats.Contains("ol"),
            _ => false
        };
    }

    /// <summary>
    /// Checks if a button is disabled
    /// </summary>
    protected bool IsButtonDisabled(ToolbarButtonType buttonType)
    {
        // Some operations require a selection
        bool requiresSelection = buttonType switch
        {
            ToolbarButtonType.Bold => true,
            ToolbarButtonType.Italic => true,
            ToolbarButtonType.Underline => true,
            ToolbarButtonType.StrikeThrough => true,
            ToolbarButtonType.Link => true,
            _ => false
        };

        return requiresSelection && !EditorState.Selection.HasSelection;
    }

    /// <summary>
    /// Creates a command for the specified button type
    /// </summary>
    private EditorCommand? CreateCommand(ToolbarButtonType buttonType)
    {
        return buttonType switch
        {
            ToolbarButtonType.Bold => FormatCommand.Bold(),
            ToolbarButtonType.Italic => FormatCommand.Italic(),
            ToolbarButtonType.Underline => FormatCommand.Underline(),
            ToolbarButtonType.StrikeThrough => FormatCommand.StrikeThrough(),
            ToolbarButtonType.Heading1 => ParagraphCommand.Heading(1),
            ToolbarButtonType.Heading2 => ParagraphCommand.Heading(2),
            ToolbarButtonType.Heading3 => ParagraphCommand.Heading(3),
            ToolbarButtonType.Paragraph => new ParagraphCommand("paragraph"),
            ToolbarButtonType.AlignLeft => ParagraphCommand.Align("left"),
            ToolbarButtonType.AlignCenter => ParagraphCommand.Align("center"),
            ToolbarButtonType.AlignRight => ParagraphCommand.Align("right"),
            ToolbarButtonType.AlignJustify => ParagraphCommand.Align("justify"),
            ToolbarButtonType.BulletList => new EditorCommand(), // Placeholder, will be implemented
            ToolbarButtonType.NumberedList => new EditorCommand(), // Placeholder, will be implemented
            ToolbarButtonType.Link => new InsertCommand("link"), // Placeholder, will show dialog
            ToolbarButtonType.Image => new InsertCommand("image"), // Placeholder, will show dialog
            ToolbarButtonType.Table => new InsertCommand("table"), // Placeholder, will show dialog
            _ => null
        };
    }
}