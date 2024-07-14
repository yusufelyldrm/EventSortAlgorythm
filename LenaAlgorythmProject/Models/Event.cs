namespace ConsoleApp2.Models;

public class Event
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Location { get; set; }
    public int Priority { get; set; }

    public Event(int id, string startTime, string endTime, string location, int priority)
    {
        Id = id;
        StartTime = TimeSpan.Parse(startTime);
        EndTime = TimeSpan.Parse(endTime);
        Location = location;
        Priority = priority;
    }
}
