# EventEase

A Blazor Web App (.NET 8, Interactive Server render mode) for browsing events,
registering attendees, and tracking check-ins — built across three Microsoft
Copilot activities and combined here into one project.

## Features

- **EventCard component** (`Components/Pages/EventCard.razor`) — a reusable
  card with two-way data binding (`@bind-Event`) so edits to name, date,
  location, and capacity flow straight back to the parent page.
- **Routing** — `Home`, `Events` (list + `/events/{id}` detail route),
  `Registration`, and `Attendance` pages, with a custom `NotFound` fallback
  and a global exception handler so bad URLs and unhandled errors show a
  friendly page instead of a blank screen.
- **Registration form** (`Registration.razor`) — `EditForm` +
  `DataAnnotationsValidator` with per-field validation messages, plus a
  manual check for an unselected event dropdown.
- **State management** (`Services/UserSessionService.cs`) — a scoped service
  that tracks the current session's registrations and notifies subscribed
  components via an `OnChange` event, so the Attendance Tracker updates
  instantly after a new registration.
- **Attendance Tracker** (`Attendance.razor`) — lists everyone registered in
  the current session with a one-click check-in toggle.

## Running locally

```bash
dotnet restore
dotnet run
```

Then open the URL shown in the console (e.g. `https://localhost:5001`).

## How Copilot assisted in each step

- **Generating the EventCard component:** I prompted Copilot to scaffold a
  Blazor component with fields for name, date, location, and capacity, and
  to wire it up for two-way binding. Copilot produced the initial
  `[Parameter]`/`EventCallback` pattern, which I then adjusted so each input
  raises its own `EventChanged` call instead of one shared handler.
- **Debugging routing:** Copilot helped trace why navigating to an unknown
  URL produced a blank page — it pointed out the `NotFound` template wasn't
  wrapped in the layout, and suggested the `LayoutView` fix used in
  `Routes.razor`. It also flagged that `/events/{id}` needed a null check
  for missing event IDs to avoid a `NullReferenceException`.
- **Performance and validation fixes:** Copilot recommended replacing
  unguarded `int.Parse`/`DateTime.Parse` calls in `EventCard` with
  `TryParse`, preventing the app from throwing on bad input. It also
  suggested capturing the loop variable locally in `Events.razor` to avoid
  the classic closure-over-iteration-variable bug when rendering multiple
  `EventCard` instances.
- **Advanced features:** For the registration form, Copilot generated the
  `DataAnnotations` attributes on the `Attendee` model and the `EditForm`
  markup. For state management, I asked Copilot for a pattern to share
  session data across components without a database, and it proposed the
  scoped service with an `OnChange` event used in `UserSessionService`. For
  the Attendance Tracker, Copilot suggested subscribing to that event in
  `OnInitialized` and unsubscribing in `Dispose` to avoid memory leaks.

## Project structure

```
EventEase/
├── Components/
│   ├── App.razor
│   ├── Routes.razor
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   └── Pages/
│       ├── Home.razor
│       ├── Events.razor
│       ├── EventCard.razor
│       ├── Registration.razor
│       ├── Attendance.razor
│       └── Error.razor
├── Models/
│   ├── EventModel.cs
│   └── Attendee.cs
├── Services/
│   ├── UserSessionService.cs
│   └── EventRepository.cs
├── wwwroot/css/app.css
├── Program.cs
└── EventEase.csproj
```
