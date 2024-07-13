using System.Net.Http;

namespace Seljmov.Blazor.Identity.Client;

/// <summary>
/// Фабрика для создания http-клиентов с авторизацией.
/// </summary>
public class AuthHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    /// <summary>
    /// Конструктор класса <see cref="AuthHttpClientFactory"/>.
    /// </summary>
    /// <param name="httpClientFactory">Фабрика http-клиентов.</param>
    public AuthHttpClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    /// <summary>
    /// Имя http-клиента с авторизацией.
    /// </summary>
    public static string AuthHttpClientName => "AuthenticatedHttpClient";

    /// <summary>
    /// Создать http-клиент с авторизацией.
    /// </summary>
    /// <returns>Http-клиент с авторизацией.</returns>
    public HttpClient CreateClient() => _httpClientFactory.CreateClient(AuthHttpClientName);
}
