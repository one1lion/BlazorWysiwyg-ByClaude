namespace BlazorWysiwyg.Models.Commands;

/// <summary>
/// Command for paragraph formatting
/// </summary>
public class ParagraphCommand : EditorCommand
{
    /// <summary>
    /// Gets the command type
    /// </summary>
    public override CommandType Type => CommandType.Paragraph;

    /// <summary>
    /// Gets the command name
    /// </summary>
    public override string Name { get; }

    /// <summary>
    /// Gets or sets the value for the paragraph command (if applicable)
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Creates a new paragraph command
    /// </summary>
    public ParagraphCommand(string name, string? value = null)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Creates a heading command with the specified level
    /// </summary>
    public static ParagraphCommand Heading(int level) => new("heading", level.ToString());

    /// <summary>
    /// Creates an alignment command
    /// </summary>
    public static ParagraphCommand Align(string alignment) => new("align", alignment);
}
