using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AvAppTabNav.Models;

public class DBHandler
{
    private string pw = "W0rstPasswordEver!";
    private string _connectionString;
    private SqlConnection _connection;
    public List<EntertainmentActivity> EntertainmentActivities { get; set; }
    public List<FitnessActivity> FitnessActivities { get; set; }
    
    public DBHandler()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost,1433",
            UserID = "sa",
            Password = pw,
            InitialCatalog = "ActivitiesDb",
            //Encrypt = false, // prevents an error
            TrustServerCertificate = true,
        };
        
        _connectionString = builder.ToString();
        
    }

    public async Task Connect()
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            await _connection.OpenAsync();
            
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"SQL Error: {ex.Message}");
        }
        catch  (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task<ObservableCollection<EntertainmentActivity>> ReadEntertainmentActivities()
    {
        var acts = new List<EntertainmentActivity>();
        var sql = "SELECT * FROM Activities INNER JOIN EntertainmentActivities ON Activities.ActivityId = EntertainmentActivities.ActivityId";
        await using var command = new SqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var fields = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                fields[i] = reader.IsDBNull(i)? "NULL" : reader.GetValue(i).ToString();
            }
            acts.Add(new EntertainmentActivity(fields[1], fields[2], double.Parse(fields[3]), int.Parse(fields[5])));
        }

        return new ObservableCollection<EntertainmentActivity>(acts);
    }
    
    public async Task<ObservableCollection<FitnessActivity>> ReadFitnessActivities()
    {
        var acts = new List<FitnessActivity>();
        var sql = "SELECT * FROM Activities INNER JOIN FitnessActivities ON Activities.ActivityId = FitnessActivities.ActivityId";
        await using var command = new SqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var fields = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                fields[i] = reader.IsDBNull(i)? "NULL" : reader.GetValue(i).ToString();
            }
            acts.Add(new FitnessActivity(fields[1], fields[2], double.Parse(fields[3]), fields[5]));
        }

        return new ObservableCollection<FitnessActivity>(acts);
    }
    
    public async Task<ObservableCollection<EntertainmentActivity>> ReadEntertainmentActivities(string query)
    {
        var acts = new List<EntertainmentActivity>();
        var sql = "SELECT * FROM Activities INNER JOIN EntertainmentActivities ON Activities.ActivityId = EntertainmentActivities.ActivityId";
        sql += query;
        //Console.WriteLine(sql);
        await using var command = new SqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var fields = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                fields[i] = reader.IsDBNull(i)? "NULL" : reader.GetValue(i).ToString();
            }
            acts.Add(new EntertainmentActivity(fields[1], fields[2], double.Parse(fields[3]), int.Parse(fields[5])));
        }

        return new ObservableCollection<EntertainmentActivity>(acts);
    }
    
    public async Task<ObservableCollection<FitnessActivity>> ReadFitnessActivities(string query)
    {
        var acts = new List<FitnessActivity>();
        var sql = "SELECT * FROM Activities INNER JOIN FitnessActivities ON Activities.ActivityId = FitnessActivities.ActivityId";
        sql += query;
        //Console.WriteLine(sql);
        await using var command = new SqlCommand(sql, _connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var fields = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                fields[i] = reader.IsDBNull(i)? "NULL" : reader.GetValue(i).ToString();
            }
            acts.Add(new FitnessActivity(fields[1], fields[2], double.Parse(fields[3]), fields[5]));
        }

        return new ObservableCollection<FitnessActivity>(acts);
    }

    public async Task AddEntry(string data)
    {
        string sql = "EXEC " + data + "\nGO";
        Console.WriteLine(sql);
        await using var command = new SqlCommand(sql, _connection);
    }
}