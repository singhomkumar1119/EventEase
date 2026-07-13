using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class EventModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    [StringLength(80, ErrorMessage = "Event name can't exceed 80 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please provide a date.")]
    public DateTime Date { get; set; } = DateTime.Today.AddDays(7);

    [Required(ErrorMessage = "Location is required.")]
    public string Location { get; set; } = string.Empty;

    [Range(1, 100000, ErrorMessage = "Capacity must be between 1 and 100000.")]
    public int Capacity { get; set; } = 50;

    public int RegisteredCount { get; set; } = 0;

    public string Description { get; set; } = string.Empty;
}
