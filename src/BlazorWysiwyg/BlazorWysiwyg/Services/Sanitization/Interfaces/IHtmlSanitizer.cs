namespace BlazorWysiwyg.Services.Sanitization.Interfaces;

/// <summary>
/// Interface for HTML sanitization
/// </summary>
public interface IHtmlSanitizer
{
    /// <summary>
    /// Sanitizes the HTML content to remove potentially malicious code
    /// </summary>
    /// <param name="html">The HTML content to sanitize</param>
    /// <returns>The sanitized HTML content</returns>
    string Sanitize(string html);

    /// <summary>
    /// Gets whether the HTML contains potentially malicious content
    /// </summary>
    /// <param name="html">The HTML content to check</param>
    /// <returns>True if the HTML contains potentially malicious content; otherwise, false</returns>
    bool ContainsMaliciousContent(string html);
}