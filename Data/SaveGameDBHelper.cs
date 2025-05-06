using SQLite;
using BeyondHana.Models;

namespace BeyondHana.Data
{
    public class SaveGameDBHelper
    {
        private static SaveGameDBHelper _instance;
        public static SaveGameDBHelper Instance => _instance ??= new SaveGameDBHelper();
        private SQLiteAsyncConnection _dbConnection;

        public SaveGameDBHelper()
        {
            var dbFileName = "SaveGame.db";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

            //// delete old db file if exists
            //if (File.Exists(dbPath))
            //{
            //    File.Delete(dbPath);
            //}

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

        // Create table if not exists
        public async Task InitAsync()
        {
            await _dbConnection.CreateTableAsync<SaveGame>();
        }

        // Get data from database in file directory
        public async Task<List<SaveGame>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<SaveGame>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return new List<SaveGame>();
            }
        }

        // Save data to database in file directory
        public async Task<int> SaveDataAsync(SaveGame save)
        {
            int result;

            if (save.save_id != 0)
            {
                result = await _dbConnection.UpdateAsync(save);
            }
            else
            {
                result = await _dbConnection.InsertAsync(save);
            }
            return result;
        }
    }
}


