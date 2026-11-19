using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.ViewModels;

public partial class EventTableViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<EntertainmentActivity>  _entertainmentActivities;
    [ObservableProperty]
    private ObservableCollection<FitnessActivity> _fitnessActivities;

    public EventTableViewModel()
    {
        _ = LoadAsync();
    }

    public async Task LoadAsync()
    {
        try
        {
            var db = new DBHandler();
            await db.Connect();
            FitnessActivities = await db.ReadFitnessActivities();
            EntertainmentActivities = await db.ReadEntertainmentActivities();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load failed: {ex.Message}");
        }
    }

    
    
}