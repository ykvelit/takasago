namespace Takasago.Domain;

public class CurrentUser(IHttpContextAccessor http)
{
    private Guid? _id;

    public Guid Id => _id ?? GetUserId();

    private Guid GetUserId()
    {
        var headerValues = http.HttpContext!.Request.Headers["UserId"];

        var userIdAsString = headerValues.FirstOrDefault();

        if (string.IsNullOrWhiteSpace(userIdAsString)) throw new InvalidOperationException("User id not found");

        _id = Guid.Parse(userIdAsString);
        return _id.Value;
    }
}