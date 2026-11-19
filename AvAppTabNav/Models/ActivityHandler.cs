using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.Models;

public partial class ActivityHandler : ObservableObject
{
    private static Task<ObservableCollection<EntertainmentActivity>> _entertainmentActivities { get; set; }
    private static Task<ObservableCollection<FitnessActivity>> _fitnessActivities { get; set; }

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
    
    public Task<ObservableCollection<EntertainmentActivity>> EntertainmentActivities
    {
        get => _entertainmentActivities;
        set
        {
            var entertainmentActivities = _entertainmentActivities;
            SetProperty(ref entertainmentActivities, value);
        }
    }

    public Task<ObservableCollection<FitnessActivity>> FitnessActivities
    {
        get => _fitnessActivities;
        set
        {
            var fitnessActivities = _fitnessActivities;
            SetProperty(ref fitnessActivities, value);
        }
    }

    public void ReadActivitiesFromCsv()
    {
        //EntertainmentActivities = CsvHandler.ReadEntertainmentActivities();
        //FitnessActivities = CsvHandler.ReadFitnessActivities();
    }

    public async void ReadActivitiesFromDB()
    {
        var dbHandler = new DBHandler();
        await dbHandler.Connect();
        EntertainmentActivities = dbHandler.ReadEntertainmentActivities();
        FitnessActivities = dbHandler.ReadFitnessActivities();
    }

    public static void AddEntertainmentActivity()
    {
        
        //_entertainmentActivities += new EntertainmentActivity("time", "event", 0.0, 5);
    }
}