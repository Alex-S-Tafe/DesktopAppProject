using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.ViewModels;

public partial class AddFitnessViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "";

    [ObservableProperty]
    private DateTimeOffset? _dateStartTime = new DateTimeOffset(DateTime.Today);

    [ObservableProperty]
    private double _cost = 0;

    [ObservableProperty]
    private int _minParticipants = 0;

    
}