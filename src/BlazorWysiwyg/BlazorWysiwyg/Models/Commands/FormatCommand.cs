namespace BlazorWysiwyg.Models.Commands;

/// <summary>
/// Command for basic text formatting
/// </summary>
public class FormatCommand : EditorCommand
{
    /// <summary>
    /// Gets the command type
    /// </summary>
    public override CommandType Type => CommandType.Format;

    /// <summary>
    /// Gets the command name
    /// </summary>
    public override string Name { get; }

    /// <summary>
    /// Gets or sets the value for the formatting (if applicable)
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Creates a new format command
    /// </summary>
    public FormatCommand(string name, string? value = null)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Creates a bold command
    /// </summary>
    public static FormatCommand Bold() => new(nameof(Bold).ToLowerInvariant());

    /// <summary>
    /// Creates an italic command
    /// </summary>
    public static FormatCommand Italic() => new(nameof(Italic).ToLowerInvariant());

    /// <summary>
    /// Creates an underline command
    /// </summary>
    public static FormatCommand Underline() => new(nameof(Underline).ToLowerInvariant());

    /// <summary>
    /// Creates a strikethrough command
    /// </summary>
    public static FormatCommand StrikeThrough() => new(nameof(StrikeThrough).ToLowerInvariant());
}
