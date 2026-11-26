using System;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvAppTabNav.ViewModels;

public partial class AddFitnessViewModel : ObservableObject
{
    private readonly ActivityHandler _activityHandler;
    
    public AddFitnessViewModel(ActivityHandler activityHandler)
    {
        _activityHandler = activityHandler;
    }
    
    [ObservableProperty]
    private string _title = "";

    [ObservableProperty] 
    private DateTime? _dateStartTime;

    [ObservableProperty] 
    private TimeSpan? _startTime;
    
    [ObservableProperty]
    private double _cost = 0;

    [ObservableProperty]
    private string _location = "";

    [ObservableProperty] private string _message = "";

    [RelayCommand]
    private void SaveFitness()
    {
        if (string.IsNullOrWhiteSpace(Title) || DateStartTime is null || string.IsNullOrWhiteSpace(Location))
        {
            Message = "Please enter a valid title, start date and location.";
            return;
        }

        if (Cost < 0)
        {
            Message = "I like the idea of paying people to get healthy, but the higher ups don't. \nEnter a valid cost (>= 0)";
            return;
        }
        
        var start = DateStartTime.Value.Date + (StartTime ?? TimeSpan.Zero);
        var activity = new FitnessActivity(start.ToString(), Title, Cost, Location);

        try
        {
            _activityHandler.AddFitnessActivity(activity);
        }
        catch (Exception ex)
        {
            Message = $"Save Failed: {ex.Message}";
            return;
        }

        Message = $"Saved \"{Title}\".";
        Title = "";
        Cost = 0;
        Location = "";
        StartTime = null;
    }
}