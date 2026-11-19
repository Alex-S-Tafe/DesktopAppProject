using System.Runtime.InteropServices.JavaScript;
using AvAppTabNav.Models;

namespace AvAppTabNav.ViewModels;

public class AddEntertainmentViewModel
{
    public void AddEntertainment(string date, string title, double cost, int minParticipants)
    {
        var act = new EntertainmentActivity(date, title, cost, minParticipants);
        
    }
}