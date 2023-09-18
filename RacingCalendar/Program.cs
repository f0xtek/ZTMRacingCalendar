namespace RacingCalendar;

internal class Program
{
    public static void Main(string[] args)
    {
        var calendar = new RaceCalendar();
        var drivers = GenerateDrivers();

        calendar.ScheduleRaces();
        calendar.AssignDriversToRaces(drivers);
        calendar.AddRemainingDriversToWaitingList(drivers);
        calendar.Show();
        calendar.ShowWaitingList();
    }

    private static Queue<Driver> GenerateDrivers()
    {
        const int totalNumberDrivers = 80;
        var drivers = new Queue<Driver>();
        for (var i = 1; i <= totalNumberDrivers; i++)
        {
            drivers.Enqueue(new Driver($"Driver {i}"));
        }
        return drivers;
    }
}
