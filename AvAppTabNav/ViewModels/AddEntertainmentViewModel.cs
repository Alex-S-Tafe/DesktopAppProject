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
    private double _cost = 0;

    [ObservableProperty]
    private int _minParticipants = 0;

    [ObservableProperty] private string _message = "";

    [RelayCommand]
    private void SaveEntertainment()
    {
        if (string.IsNullOrWhiteSpace(Title) || DateStartTime is null || MinParticipants == 0)
        {
            Message = "Please enter a valid title, start date and minimum participants.";
            return;
        }
        
        var start = DateStartTime.Value.Date + (StartTime ?? TimeSpan.Zero);
        var activity = new EntertainmentActivity(start.ToString(), Title, Cost, MinParticipants);
        
        _activityHandler.AddEntertainmentActivity(activity);
        // TODO: db saving

        Message = $"Saved \"{Title}\".";
        Title = "";
        Cost = 0;
        MinParticipants = 0;
        StartTime = null;
    }
}