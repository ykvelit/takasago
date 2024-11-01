namespace Takasago.Domain;

public class UserPreference
{
    protected UserPreference()
    {
    }

    public UserPreference(string key, string preference)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key, nameof(key));
        ArgumentException.ThrowIfNullOrWhiteSpace(preference, nameof(preference));

        Id = Guid.NewGuid();
        Key = key;
        Preference = preference;
    }

    public Guid Id { get; init; }
    public string Key { get; init; } = null!;
    public string Preference { get; init; } = null!;
    public Guid UserId { get; set; }
}