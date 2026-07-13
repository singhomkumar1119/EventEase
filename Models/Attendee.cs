using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Attendee
{
    [Required(ErrorMessage = "Full name is required.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 60 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select an event.")]
    public int EventId { get; set; }

    public bool CheckedIn { get; set; } = false;

    public DateTime RegisteredAt { get; set; } = DateTime.Now;
}
