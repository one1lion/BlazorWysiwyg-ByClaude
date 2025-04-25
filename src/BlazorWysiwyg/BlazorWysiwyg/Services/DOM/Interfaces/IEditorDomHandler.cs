namespace BlazorWysiwyg.Services.DOM.Interfaces;

using BlazorWysiwyg.Models.Commands;
using BlazorWysiwyg.Models.State;

using Microsoft.AspNetCore.Components;

/// <summary>
/// Interface for DOM manipulation in the editor
/// </summary>
public interface IEditorDomHandler
{
    /// <summary>
    /// Gets or sets the editor reference
    /// </summary>
    ElementReference EditorElement { get; set; }

    /// <summary>
    /// Initializes the editor and sets up event handlers
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// Gets the current HTML content
    /// </summary>
    Task<string> GetContentAsync();

    /// <summary>
    /// Sets the HTML content
    /// </summary>
    Task SetContentAsync(string html);

    /// <summary>
    /// Gets the current selection state
    /// </summary>
    Task<SelectionState> GetSelectionAsync();

    /// <summary>
    /// Sets the selection based on the provided state
    /// </summary>
    Task SetSelectionAsync(SelectionState selection);

    /// <summary>
    /// Executes the specified command
    /// </summary>
    Task<CommandResult> ExecuteCommandAsync(EditorCommand command);

    /// <summary>
    /// Gets the active formatting at the current selection
    /// </summary>
    Task<HashSet<string>> GetActiveFormatsAsync();

    /// <summary>
    /// Focuses the editor
    /// </summary>
    Task FocusAsync();

    /// <summary>
    /// Blurs the editor
    /// </summary>
    Task BlurAsync();

    /// <summary>
    /// Gets whether the editor has focus
    /// </summary>
    Task<bool> HasFocusAsync();
}