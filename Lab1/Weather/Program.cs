using System.Data.SQLite;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace Weather
{
    internal class Program
    {
        
        async static Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);

            Console.WriteLine("Choose option");
            Console.WriteLine("1) Display current weather");
            Console.WriteLine("2) Display database data");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter city name");
                    string cityName = Console.ReadLine();
                    string url = "https://api.openweathermap.org/data/2.5/weather?appid=4cf52bc91ecbaffc0a40296e6232db59&q="+cityName+"&units=metric&cnt=1";
                    await getWeather(url);
                    break;
                case "2":
                    ReadData(sqlite_conn);
                    break;
            }

            async Task getWeather(string url)
            {
                Console.WriteLine("Getting JSON...");
                var responseString = await client.GetStringAsync(url);
                Console.WriteLine("Parsing JSON...");
                WeatherInfo? weatherInfo = JsonSerializer.Deserialize<WeatherInfo>(responseString);
                Console.WriteLine($"cod: {weatherInfo?.cod}");
                Console.WriteLine($"city: {weatherInfo?.name}");
                Console.WriteLine($"weather temp : {weatherInfo.main?.temp}");
                Console.WriteLine($"wind speed : {weatherInfo.wind?.speed}");
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(weatherInfo.dt);
                Console.WriteLine($"date time : {dateTime}");
                Console.WriteLine($"main : {weatherInfo.weather[0].main}");
                Console.WriteLine($"description : {weatherInfo.weather[0].description}");
                InsertData(sqlite_conn, weatherInfo, dateTime);
            }
        }

        private static void ReadData(SQLiteConnection sqlite_conn)
        {
            string findRecordCommand = $"SELECT * FROM Weathers;";

            sqlite_conn.Open();
            SQLiteCommand command = new SQLiteCommand(sqlite_conn);
            command.CommandText = findRecordCommand;

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Record id:{reader.GetInt32(0)}");
                    Console.WriteLine($"City id: {reader.GetInt32(1)}");
                    Console.WriteLine($"Date: {reader.GetString(3)}");
                    Console.WriteLine($"City name: {reader.GetString(4)}");
                    Console.WriteLine($"Temperature: {reader.GetFloat(5)}");
                    Console.WriteLine($"Wind speed: {reader.GetFloat(6)}");
                    Console.WriteLine($"Main: {reader.GetString(7)}");
                    Console.WriteLine($"Description: {reader.GetString(8)}");
                    Console.WriteLine("-----------------------------");
                }
            }
            sqlite_conn.Close();
        }

        private static void InsertData(SQLiteConnection sqlite_conn, WeatherInfo weatherInfo, DateTime date)
        {
            string findRecordCommand = $"SELECT * FROM Weathers WHERE city_id={weatherInfo.id} and date_time_utc={weatherInfo.dt};";

            sqlite_conn.Open();

            SQLiteCommand command = new SQLiteCommand(sqlite_conn);
            command.CommandText = findRecordCommand;

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return;
                }
            }


            StringBuilder query = new StringBuilder();
            query.Append(
                $"INSERT INTO Weathers (city_id, date_time_utc, date_time, city_name, temperature, wind_speed, main, description) VALUES");
            query.Append(
                $"({weatherInfo.id}, {weatherInfo.dt}, '{date}','{weatherInfo.name}', {weatherInfo.main.temp}, {weatherInfo.wind.speed}, '{weatherInfo.weather[0].main}', '{weatherInfo.weather[0].description}')");

            command.CommandText = query.ToString();
            command.ExecuteNonQuery();

            sqlite_conn.Close();
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            conn.Open();
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE IF NOT EXISTS Weathers  (id INTEGER PRIMARY KEY AUTOINCREMENT, city_id INTEGER, date_time_utc INTEGER, date_time TEXT, city_name TEXT,temperature REAL, wind_speed REAL,main TEXT, description TEXT);";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}