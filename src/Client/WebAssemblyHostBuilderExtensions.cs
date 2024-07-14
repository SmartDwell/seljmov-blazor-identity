using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Seljmov.Blazor.Identity.Client;

/// <summary>
/// Методы расширения для построителя хоста WebAssembly.
/// </summary>
public static class WebAssemblyHostBuilderExtensions
{
    /// <summary>
    /// Добавить авторизацию.
    /// </summary>
    /// <param name="builder">Построитель хоста WebAssembly.</param>
    /// <exception cref="InvalidOperationException">Ошибка при загрузке конфигурации.</exception>
    public static async Task AddAuthorizationAsync(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<TokenRepository>();
        builder.Services.AddSingleton<AuthStateProvider>();
        builder.Services.AddSingleton<AuthenticationStateProvider>(provider => provider.GetRequiredService<AuthStateProvider>());
        
        var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
        var configurationOptions = await httpClient.GetFromJsonAsync<ConfigurationOptions>(RouteConstants.ConfigurationData.GetOptionsUrl());
        if (configurationOptions is null)
        {
            throw new InvalidOperationException("Not able to load configuration.");
        }
        
        var authenticationHttpClient = new HttpClient { BaseAddress = new Uri(configurationOptions.AuthenticationServerUrl) };
        
        builder.Services.AddScoped<AuthFlow>(sp =>
            new AuthFlow(
                authClientHttpClient: httpClient,
                authServerHttpClient: authenticationHttpClient,
                authStateProvider: sp.GetRequiredService<AuthStateProvider>(),
                navigation: sp.GetRequiredService<NavigationManager>()
            ));
        
        builder.Services.AddAuthorizationCore();
    }

    /// <summary>
    /// Установить состояние авторизации.
    /// </summary>
    /// <param name="builder">Построитель хоста WebAssembly.</param>
    public static async Task SetAuthorizationStateAsync(this WebAssemblyHostBuilder builder)
    {
        using var scope = builder.Services.BuildServiceProvider().CreateScope();
        var tokenRepository = scope.ServiceProvider.GetRequiredService<TokenRepository>();

        var (accessToken, refreshToken) = await tokenRepository.GetTokens();
        if (accessToken is not null && refreshToken is not null)
        {
            builder.Services
                .AddHttpClient(AuthHttpClientFactory.AuthHttpClientName, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthHttpClientHandler>();
            
            var authStateProvider = scope.ServiceProvider.GetRequiredService<AuthStateProvider>();
            await authStateProvider.Login(accessToken, refreshToken);
        }
    }
}
