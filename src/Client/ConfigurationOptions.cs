namespace Seljmov.Blazor.Identity.Client;

/// <summary>
/// Параметры конфигурации.
/// </summary>
public class ConfigurationOptions
{
    /// <summary>
    /// Путь к серверу аутентификации.
    /// </summary>
    public string AuthServerUrl { get; set; } = string.Empty;
}
