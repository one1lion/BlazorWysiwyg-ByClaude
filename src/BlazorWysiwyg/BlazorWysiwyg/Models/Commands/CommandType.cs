namespace BlazorWysiwyg.Models.Commands;

/// <summary>
/// Represents the type of editor command
/// </summary>
public enum CommandType
{
    Format,      // Formatting commands (bold, italic, etc.)
    Paragraph,   // Paragraph-level commands (alignment, headings, etc.)
    Insert,      // Insert content (link, image, table, etc.)
    List,        // List operations
    Indent,      // Indentation operations
    History      // Undo/redo operations
}
