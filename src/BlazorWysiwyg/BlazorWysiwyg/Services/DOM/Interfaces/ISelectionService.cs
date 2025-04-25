namespace BlazorWysiwyg.Services.DOM.Interfaces;

using BlazorWysiwyg.Models.State;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Interface for selection manipulation in the editor
/// </summary>
public interface ISelectionService
{
    /// <summary>
    /// Gets or sets the editor reference
    /// </summary>
    ElementReference EditorElement { get; set; }

    /// <summary>
    /// Gets the current selection state
    /// </summary>
    SelectionState GetSelection();

    /// <summary>
    /// Sets the selection based on the provided state
    /// </summary>
    void SetSelection(SelectionState selection);

    /// <summary>
    /// Gets the parent element of the current selection
    /// </summary>
    string GetParentElement();

    /// <summary>
    /// Gets the selected text
    /// </summary>
    string GetSelectedText();

    /// <summary>
    /// Surrounds the current selection with the specified HTML tag
    /// </summary>
    Task SurroundWithTagAsync(string tagName, Dictionary<string, string>? attributes = null);

    /// <summary>
    /// Inserts HTML at the current selection
    /// </summary>
    Task InsertHtmlAsync(string html);

    /// <summary>
    /// Inserts text at the current selection
    /// </summary>
    Task InsertTextAsync(string text);
}