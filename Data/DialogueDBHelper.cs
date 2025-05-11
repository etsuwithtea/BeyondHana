using BeyondHana.Models;
using SQLite;

namespace BeyondHana.Data
{
    // This class is responsible for managing the SQLite database connection and performing CRUD operations on the Dialogue table.
    public class DialogueDBHelper
    {
        private static DialogueDBHelper? _instance;
        public static DialogueDBHelper Instance => _instance ??= new DialogueDBHelper();
        private SQLiteAsyncConnection _dbConnection;

        //  Constructor
        public DialogueDBHelper()
        {
            var dbFileName = "Dialogues.db";
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

        // This method creates the Dialogue table if it doesn't exist.
        public async Task<List<Dialogue>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<Dialogue>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Dialogue>();
            }
        }
    }
}
