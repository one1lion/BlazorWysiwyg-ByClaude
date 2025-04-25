using System.Text.RegularExpressions;

using BlazorWysiwyg.Services.Sanitization.Interfaces;

namespace BlazorWysiwyg.Services.Sanitization;

/// <summary>
/// Service for HTML sanitization
/// </summary>
public partial class HtmlSanitizer : IHtmlSanitizer
{
    // Regular expressions for detecting malicious content
    private static readonly Regex _scriptTagRegex = ScriptTagRegex();
    private static readonly Regex _eventAttributeRegex = EventAttributeRegex();
    private static readonly Regex _jsUrlRegex = JavaScriptUrlRegex();
    private static readonly Regex _dataUrlRegex = DataUrlRegex();
    private static readonly Regex _iframeTagRegex = IframeTagRegex();

    // List of allowed HTML tags
    private static readonly HashSet<string> _allowedTags = new(StringComparer.OrdinalIgnoreCase)
    {
        "p", "br", "hr",
        "h1", "h2", "h3", "h4", "h5", "h6",
        "strong", "b", "em", "i", "u", "s", "strike", "del", "sup", "sub",
        "ul", "ol", "li", "dl", "dt", "dd",
        "table", "thead", "tbody", "tfoot", "tr", "th", "td",
        "a", "img", "blockquote", "code", "pre", "span", "div",
    };

    // List of allowed attributes for specific tags
    private static readonly Dictionary<string, HashSet<string>> _allowedAttributes = new(StringComparer.OrdinalIgnoreCase)
    {
        ["*"] = new(StringComparer.OrdinalIgnoreCase) { "id", "class", "style" },
        ["a"] = new(StringComparer.OrdinalIgnoreCase) { "href", "target", "rel", "title" },
        ["img"] = new(StringComparer.OrdinalIgnoreCase) { "src", "alt", "title", "width", "height" },
        ["table"] = new(StringComparer.OrdinalIgnoreCase) { "width", "border", "cellspacing", "cellpadding" },
        ["td"] = new(StringComparer.OrdinalIgnoreCase) { "colspan", "rowspan", "width", "height" },
        ["th"] = new(StringComparer.OrdinalIgnoreCase) { "colspan", "rowspan", "width", "height", "scope" }
    };

    /// <summary>
    /// Sanitizes the HTML content to remove potentially malicious code
    /// </summary>
    /// <param name="html">The HTML content to sanitize</param>
    /// <returns>The sanitized HTML content</returns>
    public string Sanitize(string html)
    {
        if (string.IsNullOrWhiteSpace(html))
        {
            return string.Empty;
        }

        // Remove script tags and content
        html = _scriptTagRegex.Replace(html, string.Empty);

        // Remove event attributes
        html = _eventAttributeRegex.Replace(html, string.Empty);

        // Remove javascript: URLs
        html = _jsUrlRegex.Replace(html, string.Empty);

        // Remove data: URLs with base64 content
        html = _dataUrlRegex.Replace(html, string.Empty);

        // Remove iframe tags and content
        html = _iframeTagRegex.Replace(html, string.Empty);

        // Use a more sophisticated approach for a real implementation
        // This is a simplified version for demonstration purposes

        return html;
    }

    /// <summary>
    /// Gets whether the HTML contains potentially malicious content
    /// </summary>
    /// <param name="html">The HTML content to check</param>
    /// <returns>True if the HTML contains potentially malicious content; otherwise, false</returns>
    public bool ContainsMaliciousContent(string html)
    {
        if (string.IsNullOrWhiteSpace(html))
        {
            return false;
        }

        // Check for script tags
        if (_scriptTagRegex.IsMatch(html))
        {
            return true;
        }

        // Check for event attributes
        if (_eventAttributeRegex.IsMatch(html))
        {
            return true;
        }

        // Check for javascript: URLs
        if (_jsUrlRegex.IsMatch(html))
        {
            return true;
        }

        // Check for data: URLs with base64 content
        if (_dataUrlRegex.IsMatch(html))
        {
            return true;
        }

        // Check for iframe tags
        if (_iframeTagRegex.IsMatch(html))
        {
            return true;
        }

        return false;
    }

    [GeneratedRegex(@"<script\b[^>]*>(.*?)</script>", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex ScriptTagRegex();
    [GeneratedRegex(@"\bon\w+\s*=", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex EventAttributeRegex();
    [GeneratedRegex(@"javascript:", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex JavaScriptUrlRegex();
    [GeneratedRegex(@"data:[^,]*base64", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex DataUrlRegex();
    [GeneratedRegex(@"<iframe\b[^>]*>(.*?)</iframe>", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex IframeTagRegex();
}