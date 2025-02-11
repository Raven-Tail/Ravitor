﻿using Ravitor.Generator.Models;
using System.Collections.Immutable;
using System.Text;

namespace Ravitor.Generator.Generators;

internal static class InterceptorGenerator
{
    public const string InterceptorLocationAttribute = $$"""
        using System;
        using System.Diagnostics;
        using System.Runtime.CompilerServices;
        using Ravitor.Contracts.Requests;
        using Microsoft.Extensions.DependencyInjection;

        namespace System.Runtime.CompilerServices
        {
            [Conditional("DEBUG")] // not needed post-build, so can evaporate it
            [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
            sealed file class InterceptsLocationAttribute : Attribute
            {
                public InterceptsLocationAttribute(int version, string data)
                {
                    _ = version;
                    _ = data;
                }
            }
        }
        """;

    public static (string HintName, string Content) Generate(ImmutableArray<InterceptorToGenerate> interceptorsToGenerate)
    {
        var sb = new StringBuilder();
        sb.AppendLine(Constants.Header);
        sb.AppendLine(InterceptorLocationAttribute);
        sb.AppendLine();

        sb.AppendLine($$"""
        namespace Ravitor.Interceptor
        {
            static file class Interceptors
            {
        """);

        var groups = interceptorsToGenerate.GroupBy(x => (x.Sender, x.Request, x.Response));
        foreach (var group in groups)
        {
            var sender = group.Key.Sender;
            var request = group.Key.Request;
            var response = group.Key.Response;

            var requestSb = new StringBuilder(request);
            requestSb.Replace("global::", "");
            requestSb.Replace('.', '_');

            foreach (var item in group)
            {
                var version = item.Location.Version; // 1
                var data = item.Location.Data; // e.g. yxKJBEhzkHdnMhHGENjk8qgBAABQcm9ncmFtLmNz
                var displayLocation = item.Location.GetDisplayLocation(); // e.g. Program.cs(19,32)

                sb.AppendLine($$"""
                            [InterceptsLocation({{version}}, "{{data}}")] // {{displayLocation}}
                    """);
            }
            sb.AppendLine($$"""
                        public static ValueTask<TResponse> Send_{{requestSb}}<TResponse>(this {{sender}} sender, IRequest<TResponse> request, CancellationToken cancellationToken = default)
                        {
                            var rqst = request as {{request}};
                            var task = sender.Send<{{request}}, {{response}}>(rqst!, cancellationToken);
                            return Unsafe.As<ValueTask<{{response}}>, ValueTask<TResponse>>(ref task);
                        }

                """);
        }
        sb.AppendLine($$"""
            }
        }

        {{Constants.Footer}}
        """);

        return ("_Interceptor.g.cs", sb.ToString());
    }
}
