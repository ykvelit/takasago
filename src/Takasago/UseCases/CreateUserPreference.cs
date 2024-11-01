using MediatR;
using Takasago.Domain;

namespace Takasago.UseCases;

public static class CreateUserPreference
{
    public record Request(string Key, string Value) : IRequest;
    
    public class Handler(UserPreferenceStore store) : IRequestHandler<Request>
    {
        public Task Handle(Request request, CancellationToken cancellationToken)
        {
            return store.AddUserPreferenceAsync(request.Key, request.Value, cancellationToken);
        }
    }
}