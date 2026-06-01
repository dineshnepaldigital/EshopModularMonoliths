using MediatR;

namespace Shared.CQRS;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
