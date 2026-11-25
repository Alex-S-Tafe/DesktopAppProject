using CsvHelper.Configuration.Attributes;


namespace AvAppTabNav.Models;

public class EntertainmentActivity : Activity
{
    private int _minParticipants;

    public int MinParticipants
    {
        get => _minParticipants;
        set => SetProperty(ref _minParticipants, value);
    }
    
    public EntertainmentActivity(string? DateStartTime, string Title, double Cost, int MinParticipants)
    {
        this.DateStartTime = DateStartTime;
        this.Title = Title;
        this.Cost = Cost;
        this.MinParticipants = MinParticipants;
    }
}