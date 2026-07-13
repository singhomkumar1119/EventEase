using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// Holds per-user session state (registered as Scoped, so each Blazor Server
/// circuit / browser tab gets its own instance). Components subscribe to
/// OnChange so the UI updates immediately when state changes anywhere in the app.
/// </summary>
public class UserSessionService
{
    public string? CurrentUserName { get; private set; }
    public List<Attendee> MyRegistrations { get; } = new();

    public event Action? OnChange;

    public void SignIn(string userName)
    {
        CurrentUserName = userName;
        NotifyStateChanged();
    }

    public void SignOut()
    {
        CurrentUserName = null;
        MyRegistrations.Clear();
        NotifyStateChanged();
    }

    public void AddRegistration(Attendee attendee)
    {
        MyRegistrations.Add(attendee);
        NotifyStateChanged();
    }

    public void CheckIn(Attendee attendee)
    {
        attendee.CheckedIn = true;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
