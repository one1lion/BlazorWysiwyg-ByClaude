using System.Text.RegularExpressions;

using BlazorWysiwyg.Services.Sanitization.Interfaces;

namespace BlazorWysiwyg.Services.Sanitization;

/// <summary>
/// Service for HTML sanitization
/// </summary>
public class HtmlSanitizer : IHtmlSanitizer
{
    // Regular expressions for detecting malicious content
    private static readonly Regex ScriptTagRegex = new(@"<script\b[^>]*>(.*?)</script>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex EventAttributeRegex = new(@"\bon\w+\s*=", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex JsUrlRegex = new(@"javascript:", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex DataUrlRegex = new(@"data:[^,]*base64", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex IframeTagRegex = new(@"<iframe\b[^>]*>(.*?)</iframe>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    // List of allowed HTML tags
    private static readonly HashSet<string> AllowedTags = new(StringComparer.OrdinalIgnoreCase)
    {
        "p", "br", "hr",
        "h1", "h2", "h3", "h4", "h5", "h6",
        "strong", "b", "em", "i", "u", "s", "strike", "del", "sup", "sub",
        "ul", "ol", "li", "dl", "dt", "dd",
        "table", "thead", "tbody", "tfoot", "tr", "th", "td",
        "a", "img", "blockquote", "code", "pre", "span", "div",
    };

    // List of allowed attributes for specific tags
    private static readonly Dictionary<string, HashSet<string>> AllowedAttributes = new(StringComparer.OrdinalIgnoreCase)
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
        html = ScriptTagRegex.Replace(html, string.Empty);

        // Remove event attributes
        html = EventAttributeRegex.Replace(html, string.Empty);

        // Remove javascript: URLs
        html = JsUrlRegex.Replace(html, string.Empty);

        // Remove data: URLs with base64 content
        html = DataUrlRegex.Replace(html, string.Empty);

        // Remove iframe tags and content
        html = IframeTagRegex.Replace(html, string.Empty);

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
        if (ScriptTagRegex.IsMatch(html))
        {
            return true;
        }

        // Check for event attributes
        if (EventAttributeRegex.IsMatch(html))
        {
            return true;
        }

        // Check for javascript: URLs
        if (JsUrlRegex.IsMatch(html))
        {
            return true;
        }

        // Check for data: URLs with base64 content
        if (DataUrlRegex.IsMatch(html))
        {
            return true;
        }

        // Check for iframe tags
        if (IframeTagRegex.IsMatch(html))
        {
            return true;
        }

        return false;
    }
}