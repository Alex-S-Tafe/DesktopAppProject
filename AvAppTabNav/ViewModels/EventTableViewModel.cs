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
    private readonly ActivityHandler _activityHandler = new();
    public Task<ObservableCollection<FitnessActivity>> FitnessActivities => _activityHandler.FitnessActivities;

    public Task<ObservableCollection<EntertainmentActivity>> EntertainmentActivities =>
        _activityHandler.EntertainmentActivities;

    public Task<EntertainmentActivity> sampleAsyncActivity => GetAsyncActivity();

    private async Task<EntertainmentActivity> GetAsyncActivity()
    {
        await Task.Delay(3000);
        return new EntertainmentActivity("date", "activity", 1.25, 5);
    }


    
}