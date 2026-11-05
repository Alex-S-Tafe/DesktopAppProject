using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.ViewModels;

public partial class EventTableViewModel : ViewModelBase
{
    /*
    private ObservableCollection<FitnessActivity> _fitnessActivities;
    private ObservableCollection<EntertainmentActivity> _entertainmentActivities;

    public ObservableCollection<FitnessActivity> FitnessActivities
    {
        get => _fitnessActivities; 
        set  => SetProperty(ref _fitnessActivities, value);
    }

    public ObservableCollection<EntertainmentActivity> EntertainmentActivities
    {
        get => _entertainmentActivities; 
        set => SetProperty(ref _entertainmentActivities, value);
    }
    */

    //public object Title { get; }

    /*
    public EventTableViewModel()
    {
        FitnessActivities = new(new CsvHandler().ReadFitnessActivities().ToList());
        EntertainmentActivities = new (new CsvHandler().ReadEntertainmentActivities());
    }
    */
}