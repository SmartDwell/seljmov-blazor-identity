using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Seljmov.Blazor.Identity.Shared;

namespace Seljmov.Blazor.Identity.Server.ApiGroups;

/// <summary>
/// Группа настроек.
/// </summary>
public static class ConfigurationGroup
{
    /// <summary>
    /// Конфигурация группы.
    /// </summary>
    /// <param name="endpoints">Маршруты.</param>
    public static void MapConfigurationGroup(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup(RouteConstants.ConfigurationData.Route);
        group.MapGet(RouteConstants.ConfigurationData.Options, GetConfigurations)
            .WithName("GetConfigurations")
            .WithSummary("Получение настроек.")
            .WithOpenApi();
    }
    
    private static Ok<ConfigurationOptions> GetConfigurations(ConfigurationOptions configurationOptions)
    {
        return TypedResults.Ok(configurationOptions);
    }
}
