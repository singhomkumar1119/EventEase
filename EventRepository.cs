using EventEase.Models;

namespace EventEase.Services;

public class EventRepository
{
    private readonly List<EventModel> _events = new()
    {
        new EventModel
        {
            Id = 1,
            Name = "Blazor Bootcamp",
            Date = DateTime.Today.AddDays(10),
            Location = "Main Auditorium",
            Capacity = 100,
            RegisteredCount = 42,
            Description = "A hands-on workshop covering Blazor components, routing, and state management."
        },
        new EventModel
        {
            Id = 2,
            Name = "Community Meetup",
            Date = DateTime.Today.AddDays(20),
            Location = "Downtown Conference Center",
            Capacity = 60,
            RegisteredCount = 18,
            Description = "Monthly meetup for local developers to network and share ideas."
        },
        new EventModel
        {
            Id = 3,
            Name = "Career Fair",
            Date = DateTime.Today.AddDays(35),
            Location = "Expo Hall B",
            Capacity = 250,
            RegisteredCount = 130,
            Description = "Connect with employers hiring across engineering and product roles."
        }
    };

    public IReadOnlyList<EventModel> GetAll() => _events;

    public EventModel? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

    public void IncrementRegistration(int id)
    {
        var ev = GetById(id);
        if (ev is not null)
        {
            ev.RegisteredCount++;
        }
    }
}
