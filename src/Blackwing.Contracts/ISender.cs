﻿using Blackwing.Contracts.Requests;

namespace Blackwing.Contracts;

public interface ISender
{
    ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

    ValueTask<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : notnull, IRequest<TResponse>;
}
