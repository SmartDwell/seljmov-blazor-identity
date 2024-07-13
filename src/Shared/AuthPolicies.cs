using System.Collections.Generic;

namespace Seljmov.Blazor.Identity.Shared;

/// <summary>
/// Политики авторизации.
/// </summary>
public static class AuthPolicies
{
    /// <summary>
    /// Политика доступа к контроллеру работы с авторизацией.
    /// </summary>
    public static string AuthPolicy => "AuthPolicy";
    
    /// <summary>
    /// Политика доступа к контроллеру работы с пользователями.
    /// </summary>
    public static string UsersPolicy => "UsersPolicy";
    
    /// <summary>
    /// Политика доступа к контроллеру работы с административными данными.
    /// </summary>
    public static string AdminPolicy => "AdminPolicy";
    
    /// <summary>
    /// Политика доступа к контроллеру работы с новостями.
    /// </summary>
    public static string NewsPolicy => "NewsPolicy";
    
    /// <summary>
    /// Политика доступа к контроллеру работы с заявками.
    /// </summary>
    public static string RequestsPolicy => "RequestPolicy";
    
    /// <summary>
    /// Политика доступа к контроллеру работы с активами.
    /// </summary>
    public static string AssetsPolicy => "AssetsPolicy";

    /// <summary>
    /// Описание политик.
    /// </summary>
    // TODO: Перевести на локализацию.
    public static IReadOnlyDictionary<string, string> PoliciesDescription = new Dictionary<string, string>
    {
        { AuthPolicy, "Доступ к контроллеру работы с авторизацией." },
        { UsersPolicy, "Доступ к контроллеру работы с пользователями." },
        { AdminPolicy, "Доступ к контроллеру работы с административными данными." },
        { NewsPolicy, "Доступ к контроллеру работы с новостями." },
        { RequestsPolicy, "Доступ к контроллеру работы с заявками." },
        { AssetsPolicy, "Доступ к контроллеру работы с активами." }
    };
    
    /// <summary>
    /// Все политики.
    /// </summary>
    public static IReadOnlyCollection<string> AllPolicies = new List<string>
    {
        AuthPolicy,
        UsersPolicy,
        AdminPolicy,
        NewsPolicy,
        RequestsPolicy,
        AssetsPolicy
    };
}
