using SQLite;

namespace BeyondHana.Models
{
    [Table("Backgrounds")]
    public class Background
    {
        [PrimaryKey, AutoIncrement]
        public int background_id { get; set; }
        public string? file_path { get; set; }
        public string? description { get; set; }
    }
}
