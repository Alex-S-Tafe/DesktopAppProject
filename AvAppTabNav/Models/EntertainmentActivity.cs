using CsvHelper.Configuration.Attributes;

namespace AvAppTabNav.Models;

public class EntertainmentActivity : Activity
{
    private int _minParticipants;

    public int MinParticipants
    {
        get => _minParticipants;
        set
        {
            SetProperty(ref _minParticipants, value);
        }
    }
    
    public EntertainmentActivity([Index(0)]string? dateStartTime, [Index(1)]string title, [Index(2)]double cost, [Index(3)]int minParticipants)
    {
        DateStartTime = dateStartTime;
        Title = title;
        Cost = cost;
        MinParticipants = minParticipants;
    }
}