using MediatR;
using Takasago.Domain;

namespace Takasago.UseCases;

public static class DeleteUserPreferences
{
    public record Request(string Key) : IRequest;
    
    public class Handler(UserPreferenceStore store) : IRequestHandler<Request>
    {
        public async Task Handle(Request request, CancellationToken cancellationToken)
        {
            await store.DeleteUserPreferencesAsync(request.Key, cancellationToken);
        }
    }
}