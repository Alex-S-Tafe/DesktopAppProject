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
        //Console.WriteLine("\nReading done. ");
    }

    public async Task ReadEntertainmentActivities()
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
                //Console.Write("{0}\t", reader.IsDBNull(i) ? "NULL" : reader.GetValue(i));
                fields[i] = reader.IsDBNull(i)? "NULL" : reader.GetValue(i).ToString();
            }
            acts.Add(new EntertainmentActivity(fields[1], fields[2], double.Parse(fields[3]), int.Parse(fields[5])));
            //Console.WriteLine(fields[2]);
        }

        EntertainmentActivities = acts;
    }
    
    public async Task ReadFitnessActivities()
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
                //Console.Write("{0}\t", reader.IsDBNull(i) ? "NULL" : reader.GetValue(i));
                fields[i] = reader.IsDBNull(i)? "NULL" : reader.GetValue(i).ToString();
            }
            acts.Add(new FitnessActivity(fields[1], fields[2], double.Parse(fields[3]), fields[5]));
            //Console.WriteLine(fields[2]);
            //Console.WriteLine();
        }

        FitnessActivities = acts;
    }
    
}