namespace OrderProcessing.Infrastructure.Messaging;

/// <summary>
/// Represents configuration settings for connecting to a message queue service.
/// </summary>
public class QueueSettings
{
    /// <summary>
    /// Gets or sets the hostname of the message queue server.
    /// </summary>
    public string Host { get; set; } = "localhost";

    /// <summary>
    /// Gets or sets the username for authenticating with the message queue.
    /// </summary>
    public string Username { get; set; } = "guest";

    /// <summary>
    /// Gets or sets the password for authenticating with the message queue.
    /// </summary>
    public string Password { get; set; } = "guest";
}
