using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.Models;

public class ActivityHandler : ObservableObject
{
    private static ObservableCollection<EntertainmentActivity> _entertainmentActivities = new ObservableCollection<EntertainmentActivity>();
    private static ObservableCollection<FitnessActivity> _fitnessActivities = new ObservableCollection<FitnessActivity>();

    private bool readFromDatabase = false;

    public ActivityHandler()
    {
        if (readFromDatabase)
        {
            // load in from DB
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
}