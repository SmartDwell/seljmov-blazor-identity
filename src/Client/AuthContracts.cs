namespace Seljmov.Blazor.Identity.Client;

/// <summary>
/// Модель для обновления токенов
/// </summary>
public class RefreshTokensDto
{
    /// <summary>
    /// Refresh-токен
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
    
    /// <summary>
    /// Информация об устройстве.
    /// </summary>
    public string? DeviceDescription { get; set; } = string.Empty;
}

/// <summary>
/// Модель токенов.
/// </summary>
public class TokensDto
{
    /// <summary>
    /// Access-токен.
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
    
    /// <summary>
    /// Refresh-токен.
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}
