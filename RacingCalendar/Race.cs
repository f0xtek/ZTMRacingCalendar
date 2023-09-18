namespace RacingCalendar;

public class Race
{
    public string Name { get; }
    public DateTime Date { get; }
    public string TrackName { get; }
    
    public readonly int MaxDrivers = 20;
    
    public List<Driver> Drivers { get; }

    public Race(string name, DateTime date, string trackName)
    {
        Name = name;
        Date = date;
        TrackName = trackName;
        Drivers = new List<Driver>();
    }

    public bool AddDriver(Driver driver)
    {
        if (Drivers.Count < MaxDrivers)
        {
            Drivers.Add(driver);
            return true;
        }

        return false;
    }
}