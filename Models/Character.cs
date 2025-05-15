using SQLite;

namespace BeyondHana.Models
{
    [Table("Characters")]
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int character_id { get; set; }
        public string? name { get; set; }
        public string? file_path { get; set; }
    }
}
