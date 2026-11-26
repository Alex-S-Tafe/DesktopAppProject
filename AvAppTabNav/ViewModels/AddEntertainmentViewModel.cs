using System;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvAppTabNav.ViewModels;

public partial class AddEntertainmentViewModel : ObservableObject
{
    private readonly ActivityHandler _activityHandler;
    
    public AddEntertainmentViewModel(ActivityHandler activityHandler)
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
    private double _cost;

    [ObservableProperty]
    private int _minParticipants;

    [ObservableProperty] private string _message = "";

    [RelayCommand]
    private void SaveEntertainment()
    {
        if (string.IsNullOrWhiteSpace(Title) || DateStartTime is null)
        {
            Message = "Please enter a valid title, start date and minimum participants.";
            return;
        }

        if (Cost < 0)
        {
            Message = "You don't want to pay people to come to an event.";
            return;
        }

        if (MinParticipants < 1)
        {
            Message = "Please enter a positive amount of participants.";
            return;
        }
        
        var start = DateStartTime.Value.Date + (StartTime ?? TimeSpan.Zero);
        var activity = new EntertainmentActivity(start.ToString(), Title, Cost, MinParticipants);

        try
        {
            _activityHandler.AddEntertainmentActivity(activity);
        }
        catch (Exception ex)
        {
            Message = $"Save Failed: {ex.Message}";
        }

        Message = $"Saved \"{Title}\".";
        Title = "";
        Cost = 0;
        MinParticipants = 0;
        StartTime = null;
    }
}