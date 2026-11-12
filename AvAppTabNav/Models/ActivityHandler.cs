using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.Models;

public partial class ActivityHandler : ObservableObject
{
    private ObservableCollection<EntertainmentActivity> _entertainmentActivities = new ObservableCollection<EntertainmentActivity>();
    private ObservableCollection<FitnessActivity> _fitnessActivities = new ObservableCollection<FitnessActivity>();

    private bool _readFromDatabase = true;

    public ActivityHandler()
    {
        if (_readFromDatabase)
        {
            ReadActivitiesFromDB();
        }
        else
        {
            ReadActivitiesFromCsv();
        }
    }
    
    public ObservableCollection<EntertainmentActivity> EntertainmentActivities 
    {
        get => _entertainmentActivities;
        set => SetProperty(ref _entertainmentActivities, value);
    }

    public ObservableCollection<FitnessActivity> FitnessActivities
    {
        get => _fitnessActivities;
        set => SetProperty(ref _fitnessActivities, value);
    }

    public void ReadActivitiesFromCsv()
    {
        EntertainmentActivities = CsvHandler.ReadEntertainmentActivities();
        FitnessActivities = CsvHandler.ReadFitnessActivities();
    }

    public async void ReadActivitiesFromDB()
    {
        var dbHandler = new DBHandler();
        await dbHandler.Connect();
        await dbHandler.ReadEntertainmentActivities();
        await dbHandler.ReadFitnessActivities();
        EntertainmentActivities = new ObservableCollection<EntertainmentActivity>(dbHandler.EntertainmentActivities);
        FitnessActivities = new ObservableCollection<FitnessActivity>(dbHandler.FitnessActivities);
        Console.WriteLine($"First Entertainment Activity: {EntertainmentActivities[0].Title}");
        Console.WriteLine($"First Fitness Activity: {FitnessActivities[0].Title}");
    }
}