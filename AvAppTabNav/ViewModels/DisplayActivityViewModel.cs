using System.Collections.Generic;
using AvAppTabNav.Models;

namespace AvAppTabNav.ViewModels;

public class DisplayActivityViewModel : ViewModelBase
{
    private List<EntertainmentActivity> _entertainmentList { get; set; }
    private List<FitnessActivity> _fitnessList { get; set; }

    public List<EntertainmentActivity> EntertainmentList => _entertainmentList;

    public List<FitnessActivity> FitnessList => _fitnessList;

    public void LoadActivities()
    {
        
    }
}