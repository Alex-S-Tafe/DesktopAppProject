using CommunityToolkit.Mvvm.ComponentModel;
using CsvHelper.Configuration.Attributes;

namespace AvAppTabNav.Models;

public class FitnessActivity : Activity
{
    private string? _location;

    public string? Location
    {
        get => _location;
        set => SetProperty(ref _location, value);
    }

    public FitnessActivity(string? DateStartTime, string Title, double Cost, string Location)
    {
        this.DateStartTime = DateStartTime;
        this.Title = Title;
        this.Cost = Cost;
        this.Location = Location;
    }
}