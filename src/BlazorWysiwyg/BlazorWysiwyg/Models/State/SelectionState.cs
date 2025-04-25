namespace BlazorWysiwyg.Models.State;

/// <summary>
/// Represents the state of a text selection in the editor
/// </summary>
public class SelectionState
{
    /// <summary>
    /// Gets or sets the start offset of the selection
    /// </summary>
    public int StartOffset { get; set; }

    /// <summary>
    /// Gets or sets the end offset of the selection
    /// </summary>
    public int EndOffset { get; set; }

    /// <summary>
    /// Gets or sets the parent element of the selection
    /// </summary>
    public string ParentElement { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the selected text
    /// </summary>
    public string SelectedText { get; set; } = string.Empty;

    /// <summary>
    /// Gets whether there is an active selection
    /// </summary>
    public bool HasSelection => EndOffset > StartOffset;

    /// <summary>
    /// Gets whether the selection is collapsed (cursor position)
    /// </summary>
    public bool IsCollapsed => StartOffset == EndOffset;

    /// <summary>
    /// Creates a collapsed selection state at the specified offset
    /// </summary>
    public static SelectionState Collapsed(int offset) => new()
    {
        StartOffset = offset,
        EndOffset = offset
    };

    /// <summary>
    /// Creates a selection state with the specified range
    /// </summary>
    public static SelectionState Range(int startOffset, int endOffset) => new()
    {
        StartOffset = startOffset,
        EndOffset = endOffset
    };
}