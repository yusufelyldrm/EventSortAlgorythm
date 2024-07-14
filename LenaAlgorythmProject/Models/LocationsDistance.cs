namespace ConsoleApp2.Models;

public class LocationsDistance
{
    public string From { get; set; }
    public string To { get; set; }
    public int DurationMinutes { get; set; }

    public LocationsDistance(string from, string to, int durationMinutes)
    {
        From = from;
        To = to;
        DurationMinutes = durationMinutes;
    }
}