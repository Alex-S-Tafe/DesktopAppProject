using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.Models;

public partial class ActivityHandler : ObservableObject
{
    public ObservableCollection<EntertainmentActivity> EntertainmentActivities { get; } = new();
    public ObservableCollection<FitnessActivity> FitnessActivities { get; } = new();

    private bool _readFromDatabase = true;

    public async Task LoadAsync()
    {
        if (_readFromDatabase)
        {
            await ReadActivitiesFromDB();
        }
        else
        {
            ReadActivitiesFromCsv();
        }
    }

    public void ReadActivitiesFromCsv()
    {
        ReplaceAll(EntertainmentActivities, CsvHandler.ReadEntertainmentActivities());
        ReplaceAll(FitnessActivities, CsvHandler.ReadFitnessActivities());
    }

    public async Task ReadActivitiesFromDB()
    {
        var dbHandler = new DBHandler();
        await dbHandler.Connect();
        var entertainment = await dbHandler.ReadEntertainmentActivities();
        var fitness = await dbHandler.ReadFitnessActivities();
        ReplaceAll(EntertainmentActivities, entertainment);
        ReplaceAll(FitnessActivities, fitness);
    }
    
    public void AddFitnessActivity(FitnessActivity activity) => InsertSorted(FitnessActivities, activity);
    public void AddEntertainmentActivity(EntertainmentActivity activity) => InsertSorted(EntertainmentActivities, activity);

    private static void ReplaceAll<T>(ObservableCollection<T> target, IEnumerable<T> items) where T : Activity
    {
        target.Clear();
        foreach (var item in items.OrderBy(a => ToDate(a.DateStartTime)))
        {
            target.Add(item);
        }
    }

    private static void InsertSorted<T>(ObservableCollection<T> target, T item) where T : Activity
    {
        var date = ToDate(item.DateStartTime);
        var index = 0;
        while (index < target.Count && ToDate(target[index].DateStartTime) <= date)
        {
            index++;
        }
        target.Insert(index, item);
    }

    private static DateTime ToDate(string? value) => DateTime.TryParse(value, out var date) ? date : DateTime.MaxValue;
}