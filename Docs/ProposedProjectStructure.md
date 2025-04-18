# BlazorWysiwyg Project Structure

## Overall Organization

```
src/BlazorWysiwyg/
├── Components/            # Razor components with code-behind files
│   ├── Core/              # Core editor components
│   ├── Toolbar/           # Toolbar and related components
│   └── Dialogs/           # Dialog components (links, images, etc.)
├── Models/                # POCOs, enums, and data models
│   ├── Configuration/     # Configuration and options classes
│   ├── Commands/          # Command pattern classes
│   └── State/             # State management classes
├── Services/              # Services and utilities
│   ├── DOM/               # DOM manipulation services
│   └── Sanitization/      # HTML sanitization services
├── Styles/                # SCSS files
│   ├── _variables.scss    # Theme variables
│   └── Components/        # Component-specific SCSS
├── Extensions/            # Extension methods
└── wwwroot/               # Static assets
    ├── css/               # Compiled CSS
    └── icons/             # SVG icons
```

## Component Structure

Each component will use a code-behind approach:

```
Components/Core/
├── WysiwygEditor.razor          # View template
├── WysiwygEditor.razor.cs       # Code-behind class
└── WysiwygEditor.razor.scss     # Component-specific styles
```

## Models Organization

```
Models/
├── Commands/
│   ├── CommandType.cs           # Command type enum
│   ├── FormatCommand.cs         # Format command class
│   └── CommandResult.cs         # Command result class
├── Configuration/
│   ├── EditorOptions.cs         # Editor configuration options
│   └── ToolbarOptions.cs        # Toolbar configuration options
└── State/
    ├── SelectionState.cs        # Text selection state
    └── EditorState.cs           # Overall editor state
```

## Services Organization

```
Services/
├── DOM/
│   ├── EditorDomHandler.cs      # DOM manipulation service
│   ├── SelectionService.cs      # Selection manipulation service
│   └── Interfaces/              # Service interfaces
│       ├── IEditorDomHandler.cs
│       └── ISelectionService.cs
└── Sanitization/
    ├── HtmlSanitizer.cs         # HTML sanitization service
    └── Interfaces/
        └── IHtmlSanitizer.cs
```

## Styles Organization

```
Styles/
├── _variables.scss              # Theme variables
├── _mixins.scss                 # SCSS mixins
├── _utilities.scss              # Utility classes
└── Components/
    ├── _editor.scss             # Editor styles
    ├── _toolbar.scss            # Toolbar styles
    └── _dialogs.scss            # Dialog styles
```

## Namespace Structure

```csharp
namespace BlazorWysiwyg.Components.Core;
namespace BlazorWysiwyg.Components.Toolbar;
namespace BlazorWysiwyg.Components.Dialogs;
namespace BlazorWysiwyg.Models.Commands;
namespace BlazorWysiwyg.Models.Configuration;
namespace BlazorWysiwyg.Models.State;
namespace BlazorWysiwyg.Services.DOM;
namespace BlazorWysiwyg.Services.Sanitization;
namespace BlazorWysiwyg.Extensions;
```

## Dependency Injection Configuration

```csharp
// In BlazorWysiwygServiceCollectionExtensions.cs
public static class BlazorWysiwygServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorWysiwyg(this IServiceCollection services, Action<EditorOptions>? configureOptions = null)
    {
        // Register services
        services.AddScoped<IEditorDomHandler, EditorDomHandler>();
        services.AddScoped<IHtmlSanitizer, HtmlSanitizer>();
        services.AddScoped<ISelectionService, SelectionService>();
        
        // Configure options
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }
        
        return services;
    }
}
```

## Component Usage Example (Code-Behind File)

```csharp
// WysiwygEditor.razor.cs
namespace BlazorWysiwyg.Components.Core;

using Microsoft.AspNetCore.Components;
using BlazorWysiwyg.Models.Configuration;
using BlazorWysiwyg.Models.State;
using BlazorWysiwyg.Services.DOM;

public partial class WysiwygEditor : ComponentBase
{
    [Inject] private IEditorDomHandler DomHandler { get; set; } = default!;
    
    [Parameter] public string Content { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> ContentChanged { get; set; }
    [Parameter] public EditorOptions Options { get; set; } = new();
    
    private ElementReference EditorRef;
    private SelectionState SelectionState = new();
    
    // Methods would be implemented here
}
```