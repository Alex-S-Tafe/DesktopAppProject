using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CsvHelper;

namespace AvAppTabNav.Models;

public partial class CsvHandler : ObservableObject
{
   
    
    public static ObservableCollection<EntertainmentActivity> ReadEntertainmentActivities()
    {
        string path = "EntertainmentActivities.CSV";
        
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<EntertainmentActivity>().ToList();
            return new ObservableCollection<EntertainmentActivity>(records);
        }
    }

    public static ObservableCollection<FitnessActivity> ReadFitnessActivities()
    {
        string path = "FitnessActivities.CSV";
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<FitnessActivity>().ToList();
            return new ObservableCollection<FitnessActivity>(records);
        }
    }
}