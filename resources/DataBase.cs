using System;
using System.IO;
using Godot;
using Microsoft.Data.Sqlite;

public class DataBase : Node2D
{
    public override void _Ready()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        System.IO.Directory.SetCurrentDirectory(baseDirectory);
        string dbPath = System.IO.Path.Combine(baseDirectory, @"resources\items.db");

        using (var connection = new SqliteConnection($@"Data Source={dbPath}"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"
                SELECT *
                FROM items
            ";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    GD.Print($"{reader["id"]}\t{reader["tag_name"]}\t{reader["category"]}");
                }
            }
        }
    }

    public override void _Process(float delta) { }
}
