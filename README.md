# BlazorWysiwyg

A lightweight, modern WYSIWYG editor component for Blazor applications with minimal JavaScript dependencies.

## Features

- Rich text editing capabilities
- Toolbar with common formatting options
- Image and table support
- Customizable configuration
- Minimal JavaScript dependencies

## Getting Started

### Installation

```shell
dotnet add package BlazorWysiwyg
```

### Basic Usage

```csharp
<BlazorWysiwyg.Components.Core.WysiwygEditor
    @bind-Content="@htmlContent"
    Options="@editorOptions" />

@code {
    private string htmlContent = "<p>Hello World!</p>";
    private EditorOptions editorOptions = new();
}
```

## License

This project is licensed under the MIT License - see the LICENSE file for details.