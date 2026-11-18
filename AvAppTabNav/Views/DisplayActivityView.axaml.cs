using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvAppTabNav.ViewModels;

namespace AvAppTabNav.Views;

public partial class DisplayActivityView : UserControl
{
    public DisplayActivityView()
    {
        InitializeComponent();
    }

    private void ToggleButton_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is ToggleButton toggleButton)
        {
            if (e.Handled) return;
            var vm = new DisplayActivityViewModel();
            var radio = (RadioButton)sender;
            //Console.WriteLine(radio.Content);
            switch (radio.Content)
            {
                case "On":
                    vm.DateOn = radio.IsChecked;
                    vm.DateBefore = !radio.IsChecked;
                    vm.DateAfter = !radio.IsChecked;
                    //Console.WriteLine(radio.Content);
                    break;
                case "Before":
                    vm.DateOn = !radio.IsChecked;
                    vm.DateBefore = radio.IsChecked;
                    vm.DateAfter = !radio.IsChecked;
                    //Console.WriteLine(radio.Content);
                    break;
                case "After":
                    vm.DateOn = !radio.IsChecked;
                    vm.DateBefore = !radio.IsChecked;
                    vm.DateAfter = radio.IsChecked;
                    //Console.WriteLine(radio.Content);
                    break;
            }
            Console.WriteLine($"On: {vm.DateOn}, Before: {vm.DateBefore}, After: {vm.DateAfter}");
        }
    }

}