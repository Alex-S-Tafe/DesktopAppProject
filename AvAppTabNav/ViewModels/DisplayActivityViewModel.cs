using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvAppTabNav.ViewModels;



public partial class DisplayActivityViewModel : ObservableObject
{
    private readonly ActivityHandler _activityHandler;

    public DisplayActivityViewModel(ActivityHandler activityHandler)
    {
        _activityHandler = activityHandler;
        EventTable = new EventTableViewModel(activityHandler);
    }

    public EventTableViewModel EventTable { get; }
    
    [ObservableProperty]
    private bool? _dateBefore = false;
    
    [ObservableProperty]
    private bool? _dateOn = true;

    [ObservableProperty]
    private bool? _dateAfter = false;

    [ObservableProperty] 
    private DateTime? _dateSelected;
    
    private List<EntertainmentActivity> _entertainmentList { get; set; }
    private List<FitnessActivity> _fitnessList { get; set; }

    public List<EntertainmentActivity> EntertainmentList => _entertainmentList;
    public List<FitnessActivity> FitnessList => _fitnessList;

    [RelayCommand]
    private async Task DisplayAll()
    {
        try
        {
            await _activityHandler.LoadAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load Failed: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task SearchActivities()
    {
        if (DateSelected is null) return;
        try
        {
            string date = DateSelected.Value.ToString(CultureInfo.InvariantCulture).Replace('/', '-');
            int period = 0;
            if (DateBefore == true) period = -1;
            if (DateOn == true) period = 0;
            if (DateAfter == true) period = 1;
            await _activityHandler.SearchAsync(date, period);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load Failed: {ex.Message}");
        }
    }

    /*
    partial void OnDateBeforeChanged(bool? value) => PrintDateState();
    partial void OnDateOnChanged(bool? value) => PrintDateState();
    partial void OnDateAfterChanged(bool? value) => PrintDateState();

    private void PrintDateState() =>
        Console.WriteLine($"On: {DateOn}, Before: {DateBefore}, After: {DateAfter}");
    */
}