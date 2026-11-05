using CommunityToolkit.Mvvm.ComponentModel;
using CsvHelper.Configuration.Attributes;

namespace AvAppTabNav.Models;

public abstract partial class Activity : ObservableObject
{
    private string? _dateStartTime;
    private string? _title;
    private double _cost;

    public string? DateStartTime
    {
        get => _dateStartTime;
        set => SetProperty(ref _dateStartTime, value);
    }
    
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
    
    public double Cost
    {
        get => _cost;
        set => SetProperty(ref _cost, value);
    }
    
}