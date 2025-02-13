﻿//HintName: PingHandler.g.cs
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
using Ravitor.Contracts.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace Ravitor.Generator;

public sealed class PingHandlerWrapper : IRequestHandler<global::Ping, global::Pong>
{
    private readonly IRequestPipelineDelegate<global::Ping, global::Pong> handler;

    public PingHandlerWrapper(
        global::PingHandler handler,
        IEnumerable<IRequestPipeline<global::Ping, global::Pong>> behaviors)
    {
        var finalHandler = (IRequestPipelineDelegate<global::Ping, global::Pong>)handler.Handle;
        foreach (var pipeline in behaviors.Reverse())
        {
            var handlerCopy = finalHandler;
            var pipelineCopy = pipeline;
            finalHandler = (global::Ping request, CancellationToken cancellationToken) => pipelineCopy.Handle(request, handlerCopy, cancellationToken);
        }
        this.handler = finalHandler;
    }

    public ValueTask<global::Pong> Handle(global::Ping request, CancellationToken cancellationToken = default)
    {
        return handler(request, cancellationToken);
    }
}

#nullable disable
