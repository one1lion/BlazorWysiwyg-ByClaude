namespace BlazorWysiwyg.Models.State;

/// <summary>
/// Represents the state of the editor
/// </summary>
public class EditorState
{
    /// <summary>
    /// Gets or sets the current HTML content
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current selection state
    /// </summary>
    public SelectionState Selection { get; set; } = new();

    /// <summary>
    /// Gets or sets whether the editor has focus
    /// </summary>
    public bool HasFocus { get; set; }

    /// <summary>
    /// Gets or sets whether the content has been modified
    /// </summary>
    public bool IsDirty { get; set; }

    /// <summary>
    /// Gets or sets the current active formats
    /// </summary>
    public HashSet<string> ActiveFormats { get; set; } = [];

    /// <summary>
    /// Gets or sets the undo history stack
    /// </summary>
    public Stack<HistoryEntry> UndoStack { get; set; } = new();

    /// <summary>
    /// Gets or sets the redo history stack
    /// </summary>
    public Stack<HistoryEntry> RedoStack { get; set; } = new();
}

/// <summary>
/// Represents a history entry for undo/redo operations
/// </summary>
public class HistoryEntry
{
    /// <summary>
    /// Gets or sets the HTML content
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selection state when this entry was created
    /// </summary>
    public SelectionState Selection { get; set; } = new();

    /// <summary>
    /// Creates a new history entry
    /// </summary>
    public HistoryEntry(string content, SelectionState selection)
    {
        Content = content;
        Selection = selection;
    }
}
