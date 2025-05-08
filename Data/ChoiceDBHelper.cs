using BeyondHana.Models;
using SQLite;

namespace BeyondHana.Data
{
    public class ChoiceDBHelper
    {
        private static ChoiceDBHelper _instance;
        public static ChoiceDBHelper Instance => _instance ??= new ChoiceDBHelper();
        private SQLiteAsyncConnection _dbConnection;

        public ChoiceDBHelper()
        {
            var dbFileName = "Choice.db";
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
        public async Task<List<Choice>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<Choice>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return new List<Choice>();
            }
        }
    }
}
