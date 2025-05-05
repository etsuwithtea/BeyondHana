using SQLite;
using BeyondHana.Models;

namespace BeyondHana.Data
{
    public class SavedSessionDBHelper
    {
        private static SavedSessionDBHelper _instance;
        public static SavedSessionDBHelper Instance => _instance ??= new SavedSessionDBHelper();
        private SQLiteAsyncConnection _dbConnection;

        public SavedSessionDBHelper()
        {
            var dbFileName = "UserSaveGamesDB.db";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

            // // delete old db file if exists
            //if (File.Exists(dbPath))
            //{
            //    Console.WriteLine("❌ [DB] พบฐานข้อมูลเก่า -> กำลังลบ");
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
            await _dbConnection.CreateTableAsync<SavedSession>();
        }

        // Get data from database in file directory
        public async Task<List<SavedSession>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<SavedSession>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return new List<SavedSession>();
            }
        }

        // Save data to database in file directory
        public async Task<int> SaveDataAsync(SavedSession save)
        {
            int result;

            if (save.ID != 0)
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


