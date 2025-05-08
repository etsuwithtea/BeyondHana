using BeyondHana.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondHana.Data
{
    public class BGMDBHelper
    {
        private static BGMDBHelper _instance;
        public static BGMDBHelper Instance => _instance ??= new BGMDBHelper();
        private SQLiteAsyncConnection _dbConnection;

        public BGMDBHelper()
        {
            var dbFileName = "BGM.db";
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
        public async Task<List<BGM>> GetDatasAsync()
        {
            try
            {
                var list = await _dbConnection.Table<BGM>().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return new List<BGM>();
            }
        }
    }
}
