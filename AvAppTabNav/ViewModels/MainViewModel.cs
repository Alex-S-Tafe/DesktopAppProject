using System.Collections.ObjectModel;
using AvAppTabNav.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ActivityHandler _activityHandler = new();
    
    public AddFitnessViewModel AddFitness { get; }
    public AddEntertainmentViewModel AddEntertainment { get; }
    public DisplayActivityViewModel DisplayActivity { get; }

    public MainViewModel()
    {
        AddFitness = new AddFitnessViewModel(_activityHandler);
        DisplayActivity = new DisplayActivityViewModel(_activityHandler);
    }

}