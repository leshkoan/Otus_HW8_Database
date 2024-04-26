using Npgsql;

string connString = "Host = localhost; Port = 54329; Username = postgres; Password = postgres123; Database = avito;";

using (var conn = new NpgsqlConnection(connString))
{
    try
    {
        conn.Open();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка открытия базы данных - {ex.Message}");
    }

    if (conn.State == System.Data.ConnectionState.Open)
    {
        Console.WriteLine("Успешное полключение к postgreSQL.");

        using (var cmd = new NpgsqlCommand("SELECT * FROM users", conn))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)}");
            }
        }

        using (var cmd = new NpgsqlCommand("SELECT * FROM items", conn))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)}");
            }
        }

        using (var cmd = new NpgsqlCommand("SELECT * FROM purchases", conn))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} {reader.GetInt32(1)}");
            }
        }

        conn.Close();
    }
}
