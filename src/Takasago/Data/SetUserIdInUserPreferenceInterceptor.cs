using Microsoft.EntityFrameworkCore.Diagnostics;
using Takasago.Domain;

namespace Takasago.Data;

public class SetUserIdInUserPreferenceInterceptor(CurrentUser user) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var userPreferences = eventData.Context.ChangeTracker.Entries<UserPreference>().ToList();

        foreach (var userPreference in userPreferences)
        {
            userPreference.Entity.UserId = user.Id;
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}