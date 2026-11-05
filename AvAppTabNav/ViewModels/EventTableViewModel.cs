using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.ViewModels;

public partial class EventTableViewModel : ViewModelBase
{
    private readonly ActivityHandler _activityHandler = new();
    public ObservableCollection<FitnessActivity> FitnessActivities => _activityHandler.FitnessActivities;
    public ObservableCollection<EntertainmentActivity> EntertainmentActivities => _activityHandler.EntertainmentActivities;
}