using SQLite;

namespace BeyondHana.Models
{
    [Table("UserSaveGames")]
    public class UserSaveGame
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Chapter { get; set; }
        public string? isSave { get; set; }
    }
}
