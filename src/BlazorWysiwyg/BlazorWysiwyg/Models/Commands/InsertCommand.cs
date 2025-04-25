namespace BlazorWysiwyg.Models.Commands;

/// <summary>
/// Command for inserting content
/// </summary>
public class InsertCommand : EditorCommand
{
    /// <summary>
    /// Gets the command type
    /// </summary>
    public override CommandType Type => CommandType.Insert;

    /// <summary>
    /// Gets the command name
    /// </summary>
    public override string Name { get; }

    /// <summary>
    /// Gets or sets the content to insert
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional attributes for the inserted content
    /// </summary>
    public Dictionary<string, string> Attributes { get; set; } = [];

    /// <summary>
    /// Creates a new insert command
    /// </summary>
    public InsertCommand(string name, string content = "", Dictionary<string, string>? attributes = null)
    {
        Name = name;
        Content = content;
        Attributes = attributes ?? [];
    }

    /// <summary>
    /// Creates a link insert command
    /// </summary>
    public static InsertCommand Link(string url, string text = "", string title = "") =>
        new("link", text, new Dictionary<string, string>
        {
            ["href"] = url,
            ["title"] = title
        });

    /// <summary>
    /// Creates an image insert command
    /// </summary>
    public static InsertCommand Image(string url, string altText = "", string title = "") =>
        new("image", string.Empty, new Dictionary<string, string>
        {
            ["src"] = url,
            ["alt"] = altText,
            ["title"] = title
        });
}