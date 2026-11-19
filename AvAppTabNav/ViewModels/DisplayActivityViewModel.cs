using System;
using System.Collections.Generic;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.ViewModels;



public partial class DisplayActivityViewModel : ObservableObject
{
    [ObservableProperty]
    private bool? _dateBefore = false;
    
    [ObservableProperty]
    private bool? _dateOn = true;

    [ObservableProperty]
    private bool? _dateAfter = false;

    [ObservableProperty] 
    private DateTimeOffset? _dateSelected;
    
    private List<EntertainmentActivity> _entertainmentList { get; set; }
    private List<FitnessActivity> _fitnessList { get; set; }

    public List<EntertainmentActivity> EntertainmentList => _entertainmentList;

    public List<FitnessActivity> FitnessList => _fitnessList;

    public void LoadActivities(){}

    partial void OnDateBeforeChanged(bool? value) => PrintDateState();
    partial void OnDateOnChanged(bool? value) => PrintDateState();
    partial void OnDateAfterChanged(bool? value) => PrintDateState();

    private void PrintDateState() =>
        Console.WriteLine($"On: {DateOn}, Before: {DateBefore}, After: {DateAfter}");
}