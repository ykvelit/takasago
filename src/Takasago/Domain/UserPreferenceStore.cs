using Microsoft.EntityFrameworkCore;
using Takasago.Data;

namespace Takasago.Domain;

public class UserPreferenceStore(AppDbContext db)
{
    private DbSet<UserPreference> UserPreferences => db.Set<UserPreference>();

    public async Task<IEnumerable<string>> GetUserPreferencesAsync(string key, CancellationToken cancellationToken)
    {
        var userPreferences = await UserPreferences
            .Where(x => x.Key == key)
            .ToListAsync(cancellationToken);

        return userPreferences
            .Select(x => x.Preference)
            .ToList();
    }

    public Task AddUserPreferenceAsync(string key, string preference, CancellationToken cancellationToken)
    {
        var userPreference = new UserPreference(key, preference);
        return UserPreferences.AddAsync(userPreference, cancellationToken).AsTask();
    }
}