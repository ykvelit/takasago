using MediatR;
using Takasago.Domain;

namespace Takasago.UseCases;

public static class GetUserPreferences
{
    public record Request(string Key) : IRequest<IEnumerable<string>>;
    
    public class Handler(UserPreferenceStore store) : IRequestHandler<Request, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(Request request, CancellationToken cancellationToken)
        {
            return store.GetUserPreferencesAsync(request.Key, cancellationToken);
        }
    }
}