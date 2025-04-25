namespace BlazorWysiwyg.Components.Core;

using System.Text;

using BlazorWysiwyg.Models.Commands;
using BlazorWysiwyg.Models.Configuration;
using BlazorWysiwyg.Models.State;
using BlazorWysiwyg.Services.DOM.Interfaces;
using BlazorWysiwyg.Services.Sanitization.Interfaces;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

/// <summary>
/// WYSIWYG editor component for Blazor
/// </summary>
public partial class WysiwygEditor : ComponentBase, IAsyncDisposable
{
    [Inject] private IEditorDomHandler DomHandler { get; set; } = default!;
    [Inject] private IHtmlSanitizer Sanitizer { get; set; } = default!;

    /// <summary>
    /// Gets or sets the HTML content of the editor
    /// </summary>
    [Parameter]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Event callback for when the content changes
    /// </summary>
    [Parameter]
    public EventCallback<string> ContentChanged { get; set; }

    /// <summary>
    /// Gets or sets the editor options
    /// </summary>
    [Parameter]
    public EditorOptions Options { get; set; } = new();

    /// <summary>
    /// Reference to the editor element
    /// </summary>
    protected ElementReference EditorRef;

    /// <summary>
    /// Reference to the toolbar component
    /// </summary>
    protected EditorToolbar? Toolbar;

    /// <summary>
    /// Gets the current editor state
    /// </summary>
    protected EditorState EditorState { get; private set; } = new();

    /// <summary>
    /// Flag to prevent infinite update loops
    /// </summary>
    private bool _isUpdating;

    /// <summary>
    /// Initializes the component
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        // Initialize the editor state
        EditorState.Content = Content;
    }

    /// <summary>
    /// Initializes the component after rendering
    /// </summary>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Set up the DOM handler
            DomHandler.EditorElement = EditorRef;
            await DomHandler.InitializeAsync();

            // Set the initial content
            await DomHandler.SetContentAsync(Content);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    /// <summary>
    /// Updates the component when parameters change
    /// </summary>
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        var contentChanged = parameters.TryGetValue<string>(nameof(Content), out var newContent) &&
                             newContent != Content;

        await base.SetParametersAsync(parameters);

        if (contentChanged && !_isUpdating)
        {
            // Apply sanitization if enabled
            if (Options.SanitizeHtml && !string.IsNullOrWhiteSpace(Content))
            {
                Content = Sanitizer.Sanitize(Content);
            }

            // Update the DOM with the new content
            await DomHandler.SetContentAsync(Content);

            // Update the editor state
            EditorState.Content = Content;
        }
    }

    /// <summary>
    /// Handles the input event
    /// </summary>
    protected async Task OnInputAsync(ChangeEventArgs args)
    {
        if (_isUpdating)
        {
            return;
        }

        try
        {
            _isUpdating = true;

            // Get the current content from the DOM
            var newContent = await DomHandler.GetContentAsync();

            // Apply sanitization if enabled
            if (Options.SanitizeHtml && !string.IsNullOrWhiteSpace(newContent))
            {
                newContent = Sanitizer.Sanitize(newContent);

                // Update the DOM with the sanitized content
                await DomHandler.SetContentAsync(newContent);
            }

            // Update the content
            if (newContent != Content)
            {
                Content = newContent;
                EditorState.Content = newContent;
                EditorState.IsDirty = true;

                // Notify parent component
                await ContentChanged.InvokeAsync(Content);
            }
        }
        finally
        {
            _isUpdating = false;
        }
    }

    /// <summary>
    /// Handles the focus event
    /// </summary>
    protected async Task OnFocusAsync()
    {
        EditorState.HasFocus = true;
    }

    /// <summary>
    /// Handles the blur event
    /// </summary>
    protected async Task OnBlurAsync()
    {
        EditorState.HasFocus = false;
    }

    /// <summary>
    /// Handles the keydown event
    /// </summary>
    protected async Task OnKeyDownAsync(KeyboardEventArgs args)
    {
        // Handle keyboard shortcuts here
        if (args.CtrlKey || args.MetaKey)
        {
            switch (args.Key.ToLowerInvariant())
            {
                case "b":
                    await ExecuteCommandAsync(FormatCommand.Bold());
                    break;
                case "i":
                    await ExecuteCommandAsync(FormatCommand.Italic());
                    break;
                case "u":
                    await ExecuteCommandAsync(FormatCommand.Underline());
                    break;
            }
        }
    }

    /// <summary>
    /// Handles the selection change event
    /// </summary>
    protected async Task OnSelectionChangeAsync()
    {
        // Update the selection state
        EditorState.Selection = await DomHandler.GetSelectionAsync();

        // Update active formats
        EditorState.ActiveFormats = await DomHandler.GetActiveFormatsAsync();

        // Update the toolbar
        await InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Executes an editor command
    /// </summary>
    protected async Task ExecuteCommandAsync(EditorCommand command)
    {
        var result = await DomHandler.ExecuteCommandAsync(command);

        if (result.Success)
        {
            // Update the content and state
            var newContent = await DomHandler.GetContentAsync();

            if (newContent != Content)
            {
                Content = newContent;
                EditorState.Content = newContent;
                EditorState.IsDirty = true;

                // Notify parent component
                await ContentChanged.InvokeAsync(Content);
            }

            // Update selection and active formats
            EditorState.Selection = await DomHandler.GetSelectionAsync();
            EditorState.ActiveFormats = await DomHandler.GetActiveFormatsAsync();

            // Update the UI
            await InvokeAsync(StateHasChanged);
        }
    }

    /// <summary>
    /// Gets the style string for the editor element
    /// </summary>
    protected string GetEditorStyle()
    {
        var sb = new StringBuilder();

        if (Options.MinHeight > 0)
        {
            sb.Append($"min-height: {Options.MinHeight}px; ");
        }

        if (Options.MaxHeight.HasValue)
        {
            sb.Append($"max-height: {Options.MaxHeight}px; overflow-y: auto; ");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Disposes of resources
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (DomHandler is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}