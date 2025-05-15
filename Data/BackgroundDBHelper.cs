using BeyondHana.Models;
using SQLite;

namespace BeyondHana.Data
{
    // This class is responsible for managing the SQLite database connection and performing CRUD operations on the Background table.
    public class BackgroundDBHelper
    {
        private static BackgroundDBHelper? _instance;
        public static BackgroundDBHelper Instance => _instance ??= new BackgroundDBHelper();
        private SQLiteAsyncConnection _dbConnection;

        // Constructor
        public BackgroundDBHelper()
        {
            var dbFileName = "Background.db";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

            // delete old db file if exists
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }

            // Check if the database file exists in the AppDataDirectory
            if (!File.Exists(dbPath))
            {
                using var stream = FileSystem.OpenAppPackageFileAsync(dbFileName).Result;
                using var fileStream = File.Create(dbPath);
                stream.CopyTo(fileStream);
            }

            // Create a new SQLiteAsyncConnection
            _dbConnection = new SQLiteAsyncConnection(dbPath);
        }

        // This method creates the Background table if it doesn't exist.
        public async Task<List<Background>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<Background>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Background>();
            }
        }
    }
}
