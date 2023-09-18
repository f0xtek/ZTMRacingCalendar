namespace RacingCalendar;

public class RaceCalendar
{
    private readonly List<Race> _races = new();
    private readonly WaitingList _waitingList = new();

    public void ScheduleRaces()
    {
        _races.Add(new Race("Race 1", new DateTime(2023, 09, 20, 10, 0, 0), "Silverstone"));
        _races.Add(new Race("Race 2", new DateTime(2023, 10, 20, 10, 0, 0), "Donnington Park"));
        _races.Add(new Race("Race 3", new DateTime(2023, 11, 20, 10, 0, 0), "Brands Hatch"));
    }

    public void AssignDriversToRaces(Queue<Driver> drivers)
    {
        foreach (var race in _races)
        {
            for (var i = 0; i < race.MaxDrivers; i++)
            {
                if (drivers.Count > 0)
                {
                    var driver = drivers.Dequeue();
                    if (race.AddDriver(driver))
                    {
                        Console.WriteLine($"Added {driver.Name} to {race.Name}");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
    
    public void AddRemainingDriversToWaitingList(Queue<Driver> drivers)
    {
        Console.WriteLine($"Adding remaining drivers to waiting list...");
        while (drivers.Count > 0)
        {
            _waitingList.AddDriver(drivers.Dequeue());
        }
    }
    
    public void Show()
    {
        Console.WriteLine("\nRACING CALENDAR");
        Console.WriteLine("===============");
        foreach (var race in _races)
        {
            Console.WriteLine($"\n{race.Name} - {race.Date} - {race.TrackName}");
            Console.WriteLine("Drivers:");
            foreach (var driver in race.Drivers)
            {
                Console.WriteLine($"\t{driver.Name}");
            }
        }
    }

    public void ShowWaitingList()
    {
        _waitingList.Show();
    }
}