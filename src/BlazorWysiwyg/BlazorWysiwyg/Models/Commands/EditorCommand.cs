namespace BlazorWysiwyg.Models.Commands;

/// <summary>
/// Base class for editor commands
/// </summary>
public abstract class EditorCommand
{
    /// <summary>
    /// Gets the type of command
    /// </summary>
    public abstract CommandType Type { get; }

    /// <summary>
    /// Gets or sets the command name
    /// </summary>
    public abstract string Name { get; }
}
