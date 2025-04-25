namespace BlazorWysiwyg.Models.Commands;

/// <summary>
/// Represents the result of executing a command
/// </summary>
public class CommandResult
{
    /// <summary>
    /// Gets or sets whether the command was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets any error message if the command failed
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Creates a successful command result
    /// </summary>
    public static CommandResult Successful() => new() { Success = true };

    /// <summary>
    /// Creates a failed command result with the specified error message
    /// </summary>
    public static CommandResult Failed(string errorMessage) => new()
    {
        Success = false,
        ErrorMessage = errorMessage
    };
}
