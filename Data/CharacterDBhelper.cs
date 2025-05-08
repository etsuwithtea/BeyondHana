using BeyondHana.Models;
using SQLite;

namespace BeyondHana.Data
{
    public class CharacterDBhelper
    {
        private static CharacterDBhelper _instance;
        public static CharacterDBhelper Instance => _instance ??= new CharacterDBhelper();
        private SQLiteAsyncConnection _dbConnection;

        public CharacterDBhelper()
        {
            var dbFileName = "Characters.db";
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
        public async Task<List<Character>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<Character>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return new List<Character>();
            }
        }
    }
}
