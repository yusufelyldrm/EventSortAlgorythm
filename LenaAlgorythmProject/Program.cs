using ConsoleApp2.Models;
public class Program
{
    public static void Main()
    {
        List<Event> events = new List<Event>
        {
            new (1, "10:00", "12:00", "A", 50),
            new (2, "10:00", "11:00", "B", 30),
            new (3, "11:30", "12:30", "A", 40),
            new (4, "14:30", "16:00", "C", 70),
            new (5, "14:25", "15:30", "B", 60),
            new (6, "13:00", "14:00", "D", 80)
        };

        List<LocationsDistance> locationsDistances = new List<LocationsDistance>
        {
            new ("A", "B", 15),
            new ("A", "C", 20),
            new ("A", "D", 10),
            new ("B", "C", 5),
            new ("B", "D", 25),
            new ("C", "D", 25)
        };

        FindEvents(events, locationsDistances);
    }

    public static void FindEvents(List<Event> events, List<LocationsDistance> distances)
    {
        //son etkinliğe gelene kadar bir currentEventten bir sonraki başlangıç saatindeki etkinliği kontrol et
        //yolu falan filan hesapla tutuyorsa currentEventi güncelle isLastEvent'mi kontrol et değilse olana kadar devam ettir
        
        List<Event> sortedEventList = events.OrderBy(e => e.StartTime).ThenByDescending(e => e.Priority).ToList();
        List<Event> eventsToGo = new List<Event>();

        Event currentEvent = sortedEventList.First();
        eventsToGo.Add(currentEvent);
        sortedEventList.Remove(currentEvent);

        while (sortedEventList.Any())
        {
            var nextEvents = sortedEventList
                .Where(e =>
                {
                    var distance = distances.FirstOrDefault(d =>
                        (d.From == currentEvent.Location && d.To == e.Location) ||
                        (d.From == e.Location && d.To == currentEvent.Location));
                    if (distance == null)
                    {
                        return false;
                    }

                    return e.StartTime >= currentEvent.EndTime.Add(new TimeSpan(0, distance.DurationMinutes, 0));
                })
                .OrderByDescending(e => e.Priority).ThenBy(e => e.StartTime)
                .ToList();

            if (!nextEvents.Any())
            {
                break;
            }

            currentEvent = nextEvents.First();
            eventsToGo.Add(currentEvent);
            sortedEventList.Remove(currentEvent);
        }

        int totalPriority = eventsToGo.Sum(e => e.Priority);

        Console.WriteLine($"Katılınabilecek Maksimum Etkinlik Sayısı: {eventsToGo.Count}");
        Console.WriteLine($"Katılınabilecek Etkinliklerin ID'leri: {string.Join(", ", eventsToGo.Select(e => e.Id))}");
        Console.WriteLine($"Toplam Değer: {totalPriority}");
    }
}