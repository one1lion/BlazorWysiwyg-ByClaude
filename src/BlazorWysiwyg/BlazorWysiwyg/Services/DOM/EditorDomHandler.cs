namespace BlazorWysiwyg.Services.DOM;

using System.Text;

using BlazorWysiwyg.Models.Commands;
using BlazorWysiwyg.Models.State;
using BlazorWysiwyg.Services.DOM.Interfaces;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

/// <summary>
/// Service for DOM manipulation in the editor
/// </summary>
public class EditorDomHandler : IEditorDomHandler
{
    private readonly ISelectionService _selectionService;
    private readonly IJSRuntime _jsRuntime;
    private DotNetObjectReference<EditorDomHandler>? _dotNetRef;
    private string _cachedContent = string.Empty;

    /// <summary>
    /// Gets or sets the editor reference
    /// </summary>
    public ElementReference EditorElement { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EditorDomHandler"/> class
    /// </summary>
    public EditorDomHandler(ISelectionService selectionService, IJSRuntime jsRuntime)
    {
        _selectionService = selectionService;
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Initializes the editor and sets up event handlers
    /// </summary>
    public async Task InitializeAsync()
    {
        _dotNetRef = DotNetObjectReference.Create(this);
        _selectionService.EditorElement = EditorElement;

        // In a real implementation, we would need minimal JS interop here
        // But for now, we'll keep it simple without JS dependencies
    }

    /// <summary>
    /// Gets the current HTML content
    /// </summary>
    public async Task<string> GetContentAsync()
    {
        // For a minimal JS approach, we could use innerHTML properties
        // but would require a small JS function
        return _cachedContent;
    }

    /// <summary>
    /// Sets the HTML content
    /// </summary>
    public async Task SetContentAsync(string html)
    {
        _cachedContent = html;
        // In a real implementation, we would update the DOM
        // with minimal JS interop
    }

    /// <summary>
    /// Gets the current selection state
    /// </summary>
    public async Task<SelectionState> GetSelectionAsync()
    {
        return await _selectionService.GetSelectionAsync();
    }

    /// <summary>
    /// Sets the selection based on the provided state
    /// </summary>
    public async Task SetSelectionAsync(SelectionState selection)
    {
        await _selectionService.SetSelectionAsync(selection);
    }

    /// <summary>
    /// Executes the specified command
    /// </summary>
    public async Task<CommandResult> ExecuteCommandAsync(EditorCommand command)
    {
        try
        {
            switch (command)
            {
                case FormatCommand formatCmd:
                    return await ExecuteFormatCommandAsync(formatCmd);
                case ParagraphCommand paragraphCmd:
                    return await ExecuteParagraphCommandAsync(paragraphCmd);
                case InsertCommand insertCmd:
                    return await ExecuteInsertCommandAsync(insertCmd);
                default:
                    return CommandResult.Failed($"Unsupported command type: {command.GetType().Name}");
            }
        }
        catch (Exception ex)
        {
            return CommandResult.Failed($"Command execution failed: {ex.Message}");
        }
    }

    private async Task<CommandResult> ExecuteFormatCommandAsync(FormatCommand command)
    {
        // Implementation would depend on the specific command
        // This is a simplified version
        var selection = await GetSelectionAsync();

        if (!selection.HasSelection)
        {
            return CommandResult.Failed("No selection to format");
        }

        // In a real implementation, we would modify the DOM
        // with minimal JS interop

        return CommandResult.Successful();
    }

    private async Task<CommandResult> ExecuteParagraphCommandAsync(ParagraphCommand command)
    {
        // Implementation would depend on the specific command
        // This is a simplified version

        // In a real implementation, we would modify the DOM
        // with minimal JS interop

        return CommandResult.Successful();
    }

    private async Task<CommandResult> ExecuteInsertCommandAsync(InsertCommand command)
    {
        try
        {
            await _selectionService.InsertHtmlAsync(BuildHtmlForInsertCommand(command));
            return CommandResult.Successful();
        }
        catch (Exception ex)
        {
            return CommandResult.Failed($"Failed to insert content: {ex.Message}");
        }
    }

    private string BuildHtmlForInsertCommand(InsertCommand command)
    {
        switch (command.Name.ToLowerInvariant())
        {
            case "link":
                return BuildLinkHtml(command);
            case "image":
                return BuildImageHtml(command);
            default:
                return command.Content;
        }
    }

    private string BuildLinkHtml(InsertCommand command)
    {
        var sb = new StringBuilder("<a");

        if (command.Attributes.TryGetValue("href", out var href))
        {
            sb.Append($" href=\"{href}\"");
        }

        if (command.Attributes.TryGetValue("title", out var title) && !string.IsNullOrWhiteSpace(title))
        {
            sb.Append($" title=\"{title}\"");
        }

        sb.Append(" target=\"_blank\" rel=\"noopener noreferrer\">");
        sb.Append(string.IsNullOrWhiteSpace(command.Content) ? href : command.Content);
        sb.Append("</a>");

        return sb.ToString();
    }

    private string BuildImageHtml(InsertCommand command)
    {
        var sb = new StringBuilder("<img");

        if (command.Attributes.TryGetValue("src", out var src))
        {
            sb.Append($" src=\"{src}\"");
        }

        if (command.Attributes.TryGetValue("alt", out var alt))
        {
            sb.Append($" alt=\"{alt}\"");
        }

        if (command.Attributes.TryGetValue("title", out var title) && !string.IsNullOrWhiteSpace(title))
        {
            sb.Append($" title=\"{title}\"");
        }

        sb.Append(" />");

        return sb.ToString();
    }

    /// <summary>
    /// Gets the active formatting at the current selection
    /// </summary>
    public async Task<HashSet<string>> GetActiveFormatsAsync()
    {
        // In a real implementation, we would check the DOM
        // with minimal JS interop
        return new HashSet<string>();
    }

    /// <summary>
    /// Focuses the editor
    /// </summary>
    public async Task FocusAsync()
    {
        // In a real implementation, we would use minimal JS interop
    }

    /// <summary>
    /// Blurs the editor
    /// </summary>
    public async Task BlurAsync()
    {
        // In a real implementation, we would use minimal JS interop
    }

    /// <summary>
    /// Gets whether the editor has focus
    /// </summary>
    public async Task<bool> HasFocusAsync()
    {
        // In a real implementation, we would use minimal JS interop
        return false;
    }

    /// <summary>
    /// Cleans up resources when the component is disposed
    /// </summary>
    public void Dispose()
    {
        _dotNetRef?.Dispose();
    }
}