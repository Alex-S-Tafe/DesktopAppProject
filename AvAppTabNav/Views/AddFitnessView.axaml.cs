using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvAppTabNav.Views;

public partial class AddFitnessView : UserControl
{
    public AddFitnessView()
    {
        InitializeComponent();
    }

    

    private void AddFitness_OnClick(object? sender, RoutedEventArgs e)
    {
        // add activity is all input valid
    }


    private void TitleText_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        
    }
    
    
}