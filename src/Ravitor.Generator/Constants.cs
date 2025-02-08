﻿namespace Ravitor;

internal static class Constants
{
    public const string Header = """
        //------------------------------------------------------------------------------
        // <auto-generated>
        //     This code was generated by the Ravitor.Generator source generator
        //
        //     Changes to this file may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #nullable enable
        """;

    //using Microsoft.Extensions.DependencyInjection;
    //    using Ravitor.Contracts;
    //    using Ravitor.Contracts.Handlers;

    public const string Footer = """
        #nullable disable
        """;

    public static class Assembly
    {
        public const string Name = "Ravitor.Contracts";
    }

    public static class Generator
    {
        public const string Namespace = "Ravitor.Generator";
        public const string ServiceCollectionFile = "_ServiceCollectionExtensions.g.cs";
        public const string InterceptorFile = "_Interceptor.g.cs";
    }

    public static class Handlers
    {
        public const string Namespace = "Ravitor.Contracts.Handlers";
        public const string IRequestHandlerFull = "Ravitor.Contracts.Handlers.IRequestHandler";
        public const string IRequestHandler = "IRequestHandler";
    }

    public static class Pipelines
    {
        public const string Namespace = "Ravitor.Contracts.Pipelines";
        public const string IRequestPipelineDelegate = "IRequestPipelineDelegate";
        public const string IRequestPipelineFull = "Ravitor.Contracts.Pipelines.IRequestPipeline";
        public const string IRequestPipeline = "IRequestPipeline";
    }

    public static class Requests
    {
        public const string Namespace = "Ravitor.Contracts.Requests";
        public const string IRequestFull = "Ravitor.Contracts.Requests.IRequest";
        public const string IRequest = "IRequest";
    }

    public static class Mediator
    {
        public const string Namespace = "Ravitor.Contracts";
        public const string IMediatorFull = "Ravitor.Contracts.IMediator";
        public const string IMediator = "IMediator";
    }

    public static class Sender
    {
        public const string Namespace = "Ravitor.Contracts";
        public const string ISenderFull = "Ravitor.Contracts.ISender";
        public const string ISender = "ISender";
        public const string SendMethod = "Send";
    }
}
