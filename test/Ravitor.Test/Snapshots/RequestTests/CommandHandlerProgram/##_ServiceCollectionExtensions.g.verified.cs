﻿//HintName: _ServiceCollectionExtensions.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Ravitor.Generator source generator
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

using Ravitor.Contracts.Handlers;

namespace Microsoft.Extensions.DependencyInjection;

internal static class RavitorServiceCollectionExtensions
{
    public static IServiceCollection AddRavitorHandlers(this IServiceCollection services)
    {
        services.AddScoped<global::Ravitor.Test.Integration.PingCommandHandler>();
        services.AddScoped<global::Ravitor.Generator.Ravitor.Test.Integration.PingCommandHandlerWrapper>();
        services.AddScoped<IRequestHandler<global::Ravitor.Test.Integration.Ping, global::Ravitor.Test.Integration.Result<global::Ravitor.Test.Integration.Pong>>, global::Ravitor.Generator.Ravitor.Test.Integration.PingCommandHandlerWrapper>(static sp => sp.GetRequiredService<global::Ravitor.Generator.Ravitor.Test.Integration.PingCommandHandlerWrapper>());

        return services;
    }
}

#nullable disable
