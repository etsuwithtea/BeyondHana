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
            Console.WriteLine("🔧 [Constructor] เริ่มทำงาน");

            var dbFileName = "UserSaveGamesDB.db";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

            //เวลาจะเปลี่ยนข้อมูล
            // ลบไฟล์ฐานข้อมูลเก่าจาก AppDataDirectory ก่อน
            //if (File.Exists(dbPath))
            //{
            //    Console.WriteLine("❌ [DB] พบฐานข้อมูลเก่า -> กำลังลบ");
            //    File.Delete(dbPath);
            //}

            // เช็กว่าไฟล์ DB เคยถูกคัดลอกมาแล้วหรือยัง
            if (!File.Exists(dbPath))
            {
                Console.WriteLine("📁 [DB] ยังไม่พบ DB -> กำลังคัดลอกจาก Resources");

                using var stream = FileSystem.OpenAppPackageFileAsync(dbFileName).Result;
                using var fileStream = File.Create(dbPath);
                stream.CopyTo(fileStream);

                Console.WriteLine("✅ [DB] คัดลอกเสร็จสมบูรณ์: " + dbPath);
            }
            else
            {
                Console.WriteLine("ℹ️ [DB] พบ DB เดิมแล้ว -> ใช้งานต่อ: " + dbPath);
            }

            // เปิดการเชื่อมต่อ SQLite ไปยังไฟล์ที่เขียนได้
            _dbConnection = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitAsync()
        {
            Console.WriteLine("📥 [Init] เริ่มสร้างตาราง...");
            await _dbConnection.CreateTableAsync<SavedSession>();
            Console.WriteLine("🛠️ [DB] ตารางพร้อมใช้งานแล้ว");
        }

        public async Task<List<SavedSession>> GetNotesAsync()
        {
            try
            {
                var list = await _dbConnection.Table<SavedSession>().ToListAsync();
                Console.WriteLine($"📄 [DB] พบข้อมูลจำนวน: {list.Count}");
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ [DB ERROR] " + ex.Message);
                return new List<SavedSession>();
            }
        }

        public async Task<int> SaveNoteAsync(SavedSession savegame)
        {
            int result;

            if (savegame.ID != 0)
            {
                Console.WriteLine("🔄 [DB] กำลังอัพเดตข้อมูล...");
                result = await _dbConnection.UpdateAsync(savegame);
            }
            else
            {
                Console.WriteLine("💾 [DB] กำลังเพิ่มข้อมูลใหม่...");
                result = await _dbConnection.InsertAsync(savegame);
            }

            return result;
        }
    }
}


